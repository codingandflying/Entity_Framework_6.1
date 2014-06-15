using EFDataAccessLayer.BaseTypes;
using EFDataAccessLayer.Entities.ValidationExtensions;
using System;
using System.Collections.Generic;

namespace EFDataAccessLayer.Entities
{
     /// <summary>
    /// Representes a category for transactions account in the application. Inherits from <see cref="EntityBase"/>.
    /// </summary>
    public class Category : EntityBase
    {
        //_________________________________________________________________________________________
        #region Stores

        private string _Name;
        private bool _IsMainCategory;
        private List<Category> _SubCategories;
        private string _Comment;

        #endregion

        //_________________________________________________________________________________________
        #region Properties

        /// <summary>
        /// Primary Key.
        /// </summary>
        public int ID { get; private set; }

        /// <summary>
        /// Category Name.
        /// <para>Required.</para>
        /// <para>Max Length: Settings.Default.ShortStringLength</para>
        /// </summary>
        public string Name
        {
            get { return _Name; }
            set { SetProperty<string>("Name", ref _Name, value); }
        }

        /// <summary>
        /// Main Category identifier.
        /// <para>Required.</para>
        /// </summary>
        public bool IsMainCategory
        {
            get { return _IsMainCategory; }
            set { SetProperty<bool>("IsMainCategory", ref _IsMainCategory, value); }
        }

        /// <summary>
        /// Sub categories if this is a min category.
        /// <para>Required.</para>
        /// </summary>
        public List<Category> SubCategories
        {
            get { return _SubCategories; }
            set { SetProperty<List<Category>>("SubCategories", ref _SubCategories, value); }
        }

        /// <summary>
        /// Notes about the account.
        /// <para>Not Required.</para>
        /// <para>Max Length: Settings.Default.LongStringLength</para>
        /// </summary>
        public string Comment
        {
            get { return _Comment; }
            set { SetProperty<string>("Comment", ref _Comment, value); }
        }

        #endregion

        //_________________________________________________________________________________________
        #region Constructors

        public Category()
        {
            RegisterValidationMethods();

            ResetProperties();

        }

        #endregion

        //_________________________________________________________________________________________
        #region EntityBaseOverrides

        protected override void RegisterValidationMethods()
        {
            AddValidationMethod("Name", this.ValidateName);
            AddValidationMethod("IsMainCategory", this.ValidateIsMainCategory);
            AddValidationMethod("SubCategories", this.ValidateSubCategories);
            AddValidationMethod("Comment", this.ValidateComment);
        }

        protected override void ResetProperties()
        {
            Name = null;
            IsMainCategory = true;
            SubCategories = null;
            Comment = null;
        }

        #endregion


    }
}
