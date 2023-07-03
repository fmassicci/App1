using App1.Infrastructure.Messenger;
using App1.Infrastructure.ViewModels;
using App1.Services;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using System.Threading.Tasks;

namespace App1.ViewModels;
public abstract partial class GenericDetailsViewModel<TModel> : ViewModelBase where TModel : ExtendedObservableValidator, new()
{
    public GenericDetailsViewModel(ICommonServices commonServices) : base(commonServices)
    {
        WeakReferenceMessenger.Default.Register<BeginEditMessage>(this, (r, m) =>
        {
            OnEdit();
        });

        WeakReferenceMessenger.Default.Register<CancelEditMessage>(this, (r, m) =>
        {
            CancelEdit();
        });

        WeakReferenceMessenger.Default.Register<NewItemSavedMessage>(this, (r, m) =>
        {
            OnSave();
        });

        WeakReferenceMessenger.Default.Register<ItemChangedMessage>(this, (r, m) =>
        {
            OnSave();
        });

        WeakReferenceMessenger.Default.Register<ItemDeletedMessage>(this, (r, m) =>
        {
            OnDelete();
        });
    }

    //public ILookupTables LookupTables => LookupTablesProxy.Instance;

    public bool IsDataAvailable => _item != null;
    public bool IsDataUnavailable => !IsDataAvailable;

    //public bool CanGoBack => !IsMainView && NavigationService.CanGoBack;

    private TModel _item = null;
    //[NotifyPropertyChangedFor(nameof(IsDataAvailable))]
    //[NotifyPropertyChangedFor(nameof(IsDataUnavailable))]
    //[NotifyPropertyChangedFor(nameof(Title))]
    public TModel Item
    {
        get => _item;
        set
        {
            if (SetProperty(ref _item, value))
            {
                EditableItem = _item;
                IsEnabled = (!_item?.IsEmpty) ?? false;
                OnPropertyChanged(nameof(IsDataAvailable));
                OnPropertyChanged(nameof(IsDataUnavailable));
                OnPropertyChanged(nameof(Title));
            }
        }
    }

    private TModel _editableItem = null;
    public TModel EditableItem
    {
        get => _editableItem;
        set => SetProperty(ref _editableItem, value);
    }

    private bool _isEditMode = false;
    public bool IsEditMode
    {
        get => _isEditMode;
        set => SetProperty(ref _isEditMode, value);
    }

    private bool _isEnabled = true;
    public bool IsEnabled
    {
        get => _isEnabled;
        set => SetProperty(ref _isEnabled, value);
    }

    //public ICommand BackCommand => new RelayCommand(OnBack);
    [RelayCommand]
    protected virtual void OnBack()
    {
        StatusReady();
        if (NavigationService.CanGoBack)
        {
            NavigationService.GoBack();
        }
    }

    //public ICommand EditCommand => new RelayCommand(OnEdit);

    [RelayCommand]
    protected virtual void OnEdit()
    {
        StatusReady();
        BeginEdit();
        WeakReferenceMessenger.Default.Send(new BeginEditMessage(Item));
        //MessageService.Send(this, "BeginEdit", Item);
    }

    public virtual void BeginEdit()
    {
        if (!IsEditMode)
        {
            IsEditMode = true;
            // Create a copy for edit
            var editableItem = new TModel();
            editableItem.Merge(Item);
            EditableItem = editableItem;
        }
    }

    //public ICommand CancelCommand => new RelayCommand(OnCancel);
    [RelayCommand]
    protected virtual void OnCancel()
    {
        StatusReady();
        CancelEdit();
        WeakReferenceMessenger.Default.Send(new CancelEditMessage(Item));
        //MessageService.Send(this, "CancelEdit", Item);
    }
    public virtual void CancelEdit()
    {
        if (ItemIsNew)
        {
            // We were creating a new item: cancel means exit
            if (NavigationService.CanGoBack)
            {
                NavigationService.GoBack();
            }
            else
            {
                NavigationService.GoBack();
            }
            return;
        }

        // We were editing an existing item: just cancel edition
        if (IsEditMode)
        {
            EditableItem = Item;
        }
        IsEditMode = false;
    }

    //public ICommand SaveCommand => new RelayCommand(OnSave);

    [RelayCommand]
    protected async virtual void OnSave()
    {
        StatusReady();
        //var result = Validate(EditableItem);

        if (result.IsOk)
        {
            await SaveAsync();
        }
        else
        {
            await DialogService.ShowAsync(result.Message, $"{result.Description} Prego, correggere l'errore e riprovare.",
                                            App.MainWindow.Content.XamlRoot);
        }
    }
    public async virtual Task SaveAsync()
    {
        IsEnabled = false;
        bool isNew = ItemIsNew;
        if (await SaveItemAsync(EditableItem))
        {
            Item.Merge(EditableItem);
            //Item.NotifyChanges();
            OnPropertyChanged(nameof(Title));
            EditableItem = Item;

            if (isNew)
            {
                WeakReferenceMessenger.Default.Send(new CancelEditMessage(Item));
                //MessageService.Send(this, "NewItemSaved", Item);
            }
            else
            {
                WeakReferenceMessenger.Default.Send(new ItemChangedMessage(Item));
                //MessageService.Send(this, "ItemChanged", Item);
            }
            IsEditMode = false;

            OnPropertyChanged(nameof(ItemIsNew));
        }
        IsEnabled = true;
    }

    //public ICommand DeleteCommand => new RelayCommand(OnDelete);
    [RelayCommand]
    protected async virtual void OnDelete()
    {
        StatusReady();
        if (await ConfirmDeleteAsync())
        {
            await DeleteAsync();
        }
    }
    public async virtual Task DeleteAsync()
    {
        var model = Item;
        if (model != null)
        {
            IsEnabled = false;
            if (await DeleteItemAsync(model))
            {
                WeakReferenceMessenger.Default.Send(new ItemDeletedMessage(model));
                //MessageService.Send(this, "ItemDeleted", model);
            }
            else
            {
                IsEnabled = true;
            }
        }
    }

    public virtual Result Validate(TModel model)
    {
        foreach (var constraint in GetValidationConstraints(model))
        {
            if (!constraint.Validate(model))
            {
                return Result.Error("Errore di validazione", constraint.Message);
            }
        }
        return Result.Ok();
    }

    protected virtual IEnumerable<IValidationConstraint<TModel>> GetValidationConstraints(TModel model) => Enumerable.Empty<IValidationConstraint<TModel>>();

    public abstract bool ItemIsNew
    {
        get;
    }

    protected abstract Task<bool> SaveItemAsync(TModel model);
    protected abstract Task<bool> DeleteItemAsync(TModel model);
    protected abstract Task<bool> ConfirmDeleteAsync();
}
