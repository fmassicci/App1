using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.ComponentModel;
using System.Diagnostics;

namespace App1.Infrastructure.ViewModels;
public class ExtendedObservableValidator : ObservableValidator
{
    public bool IsEmpty
    {
        get;
        set;

    }

    public virtual void Merge(ObservableValidator source)
    {
    }

    public virtual void VerifyPropertyName(string propertyName)
    {
        if (TypeDescriptor.GetProperties(this)[propertyName] == null)
        {
            var msg = "Il nome della proprietà non è valido: " + propertyName;

            if (this.ThrowOnInvalidPropertyName)
                throw new Exception(msg);
            else
                Debug.Fail(msg);
        }
    }

    protected virtual bool ThrowOnInvalidPropertyName
    {
        get; private set;
    }
}
