using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace ATProManagement.Base;

public static class ModelExtension
{
    public static TDestination ToModel<TDestination>(this object source)
       where TDestination : new()
    {
        if (source == null)
            return default!;

        var destination = new TDestination();

        var sourceProperties = source.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);
        var destinationProperties = typeof(TDestination).GetProperties(BindingFlags.Public | BindingFlags.Instance);

        foreach (var destProp in destinationProperties)
        {
            if (!destProp.CanWrite)
                continue;

            var sourceProp = sourceProperties.FirstOrDefault(x =>
                x.Name == destProp.Name &&
                x.PropertyType == destProp.PropertyType);

            if (sourceProp == null)
                continue;

            var value = sourceProp.GetValue(source);

            destProp.SetValue(destination, value);
        }

        return destination;
    }
}

