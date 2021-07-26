using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using HandyControl.Controls;

public class EnumStrPropertyEditor : PropertyEditorBase
{
    public override FrameworkElement CreateElement(PropertyItem propertyItem)
    {
        System.Windows.Controls.ComboBox comboBox = new System.Windows.Controls.ComboBox();
        comboBox.IsEnabled = !propertyItem.IsReadOnly;
        comboBox.ItemsSource = PropertyGrid.EnumStrItem;
        comboBox.DisplayMemberPath = "Name";
        comboBox.SelectedValuePath = "Value";
        return comboBox;
    }

    public override DependencyProperty GetDependencyProperty()
    {
        return Selector.SelectedValueProperty;
    }
}
