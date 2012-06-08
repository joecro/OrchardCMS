﻿using System;
using System.Globalization;
using Orchard.ContentManagement;
using Orchard.ContentManagement.FieldStorage;

namespace Orchard.Fields.Fields {
    public class EnumerationField : ContentField {
        private const char Separator = ';';

        public string Value {
            get { return Storage.Get<string>(); }
            set { Storage.Set(value ?? String.Empty); }
        }

        public string[] SelectedValues {
            get {
                var value = Value;
                if(string.IsNullOrWhiteSpace(value)) {
                    return new string[0];
                }

                return value.Split(new [] { Separator }, StringSplitOptions.RemoveEmptyEntries);
            }

            set {
                Value = Separator + string.Join(Separator.ToString(), value) + Separator;
            }
        }
    }
}
