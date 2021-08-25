using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Windows;
using System.Windows.Controls.Primitives;

namespace HandyControl.Controls
{
    public class EnumPropertyEditor : PropertyEditorBase
    {
        public override FrameworkElement CreateElement(PropertyItem propertyItem)
        {
            System.Windows.Controls.ComboBox comboBox = new System.Windows.Controls.ComboBox();
            comboBox.IsEnabled = !propertyItem.IsReadOnly;
            List<CategoryInfo> list = new List<CategoryInfo>();
            Array values = Enum.GetValues(propertyItem.PropertyType);
            foreach (object item2 in values)
            {
                FieldInfo field = item2.GetType().GetField(item2.ToString());
                object[] customAttributes = field.GetCustomAttributes(typeof(DescriptionAttribute), inherit: false);
                string name = item2.ToString();
                if (customAttributes.Length != 0)
                {
                    DescriptionAttribute descriptionAttribute = customAttributes[0] as DescriptionAttribute;
                    name = descriptionAttribute.Description;
                }
                CategoryInfo item = new CategoryInfo
                {
                    Name = name,
                    Value = item2.ToString()
                };
                list.Add(item);
            }
            comboBox.ItemsSource = list;
            comboBox.DisplayMemberPath = "Name";
            comboBox.SelectedValuePath = "Value";
            return comboBox;
        }

        public override DependencyProperty GetDependencyProperty()
        {
            return Selector.SelectedValueProperty;
        }
    }
}
