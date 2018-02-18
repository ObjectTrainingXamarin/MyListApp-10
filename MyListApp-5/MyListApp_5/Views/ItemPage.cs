//
// Copyright (c), 2017. Object Training Pty Ltd. All rights reserved.
// Written by Tim Hastings.
//

using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace MyListApp
{
    /// <summary>
    /// Item page for updates and new items.
    /// </summary>
    public class ItemPage : ContentPage
    {
        Label idLabel = new Label();    // For illustrative purposes only
        Entry nameEntry = new Entry() { Placeholder = "Name" };
        Entry addressEntry = new Entry() { Placeholder = "Address" };
        Entry detailEntry = new Entry() { Placeholder = "Detail" };
        Picker iconPicker = new Picker();
        Image icon = new Image() { HeightRequest = 32, WidthRequest = 32 };
        Button saveButton = new Button() { Text = "Save" };

        Item _item = new Item();
        bool _isNew = false;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:MyListApp.ItemPage"/> class.
        /// </summary>
        /// <param name="item">Item.</param>
        /// <param name="isNew">If set to <c>true</c> is a new item.</param>
        public ItemPage(Item item, bool isNew)
        {
            Title = "Item";
            _item = item;
            _isNew = isNew;

            idLabel.Text = "Id = " + item.id.ToString();
            nameEntry.Text = item.Name;
            addressEntry.Text = item.Address;
            detailEntry.Text = item.Detail;
            icon.Source = item.Icon.Source;

            //	Setup the image picker
            String source = item.Icon.Source as FileImageSource;
            var list = new List<String>() { "avatar.png", "businessman.png", "businesswoman.png" };
            int index = 0;
            foreach (var i in list)
                iconPicker.Items.Add(i);

            for (int i = 0; i < list.Count; i++)
                if (list[i] == source)
                    index = i;

            iconPicker.SelectedIndex = index;

            Content = new StackLayout
            {
                Spacing = 10,
                Children = {
                    idLabel,
                    nameEntry,
                    addressEntry,
                    detailEntry,
                    iconPicker,
                    icon,
                    saveButton
                }
            };

            //	Events
            saveButton.Clicked += OnSaveClicked;
            iconPicker.SelectedIndexChanged += OnIconChanged;
        }

        /// <summary>
        /// Save the item.
        /// </summary>
        /// <param name="o">O.</param>
        /// <param name="args">Arguments.</param>
        void OnSaveClicked(Object o, EventArgs args)
        {
            //	Get the data
            _item.Name = nameEntry.Text;
            _item.Address = addressEntry.Text;
            _item.Detail = detailEntry.Text;
            _item.Icon.Source = iconPicker.Items[iconPicker.SelectedIndex];

            if (_isNew)
                Model.Add(_item);
            else
                Model.Update(_item);

            Database.SaveModel();

            //	Go back
            Navigation.PopAsync();
        }

        /// <summary>
        /// When the icon changes update the image.
        /// </summary>
        /// <param name="o">O.</param>
        /// <param name="args">Arguments.</param>
        void OnIconChanged(object o, EventArgs args)
        {
            String source = iconPicker.Items[iconPicker.SelectedIndex].ToString();
            icon.Source = source;
        }
    }
}