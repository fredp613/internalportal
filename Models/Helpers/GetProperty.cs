using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using InternalPortal.Models.Portal.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace InternalPortal.Models.Helpers
{
    public class GetProperty
    {
        
        

        public static void TrySetProperty(object obj, string property, object value)
        {
            
            var prop = obj.GetType().GetProperty(property, BindingFlags.Public | BindingFlags.Instance);
            if (prop != null && prop.CanWrite)
                prop.SetValue(obj, value, null);

        }


        public static void TrySetPropertyAsync(object obj, string property, string value)
        {
            //var getProp = new GetProperty<TEntity>
            //{
            //    _entity = obj,
            //    _property = property,
            //    _value = value
            //};

            var prop = obj.GetType().GetProperty(property, BindingFlags.Public | BindingFlags.Instance);
            if (prop != null && prop.CanWrite)
                prop.SetValue(obj, value, null);
        }


    }
}
