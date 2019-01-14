﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace services
{
	using System.Data.Linq;
	using System.Data.Linq.Mapping;
	using System.Data;
	using System.Collections.Generic;
	using System.Reflection;
	using System.Linq;
	using System.Linq.Expressions;
	using System.ComponentModel;
	using System;
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="db")]
	public partial class DatabaseDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InsertClient(Client instance);
    partial void UpdateClient(Client instance);
    partial void DeleteClient(Client instance);
    partial void InsertDog(Dog instance);
    partial void UpdateDog(Dog instance);
    partial void DeleteDog(Dog instance);
    #endregion
		
		public DatabaseDataContext() : 
				base(global::services.Properties.Settings.Default.dbConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public DatabaseDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DatabaseDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DatabaseDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DatabaseDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<Client> Clients
		{
			get
			{
				return this.GetTable<Client>();
			}
		}
		
		public System.Data.Linq.Table<Dog> Dogs
		{
			get
			{
				return this.GetTable<Dog>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Clients")]
	public partial class Client : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _client_id;
		
		private string _client_name;
		
		private string _client_surname;
		
		private EntitySet<Dog> _Dogs;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void Onclient_idChanging(int value);
    partial void Onclient_idChanged();
    partial void Onclient_nameChanging(string value);
    partial void Onclient_nameChanged();
    partial void Onclient_surnameChanging(string value);
    partial void Onclient_surnameChanged();
    #endregion
		
		public Client()
		{
			this._Dogs = new EntitySet<Dog>(new Action<Dog>(this.attach_Dogs), new Action<Dog>(this.detach_Dogs));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_client_id", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int client_id
		{
			get
			{
				return this._client_id;
			}
			set
			{
				if ((this._client_id != value))
				{
					this.Onclient_idChanging(value);
					this.SendPropertyChanging();
					this._client_id = value;
					this.SendPropertyChanged("client_id");
					this.Onclient_idChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_client_name", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string client_name
		{
			get
			{
				return this._client_name;
			}
			set
			{
				if ((this._client_name != value))
				{
					this.Onclient_nameChanging(value);
					this.SendPropertyChanging();
					this._client_name = value;
					this.SendPropertyChanged("client_name");
					this.Onclient_nameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_client_surname", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string client_surname
		{
			get
			{
				return this._client_surname;
			}
			set
			{
				if ((this._client_surname != value))
				{
					this.Onclient_surnameChanging(value);
					this.SendPropertyChanging();
					this._client_surname = value;
					this.SendPropertyChanged("client_surname");
					this.Onclient_surnameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Client_Dog", Storage="_Dogs", ThisKey="client_id", OtherKey="dog_owner_id")]
		public EntitySet<Dog> Dogs
		{
			get
			{
				return this._Dogs;
			}
			set
			{
				this._Dogs.Assign(value);
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_Dogs(Dog entity)
		{
			this.SendPropertyChanging();
			entity.Client = this;
		}
		
		private void detach_Dogs(Dog entity)
		{
			this.SendPropertyChanging();
			entity.Client = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Dogs")]
	public partial class Dog : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _dog_id;
		
		private string _dog_name;
		
		private System.Nullable<int> _dog_owner_id;
		
		private EntityRef<Client> _Client;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void Ondog_idChanging(int value);
    partial void Ondog_idChanged();
    partial void Ondog_nameChanging(string value);
    partial void Ondog_nameChanged();
    partial void Ondog_owner_idChanging(System.Nullable<int> value);
    partial void Ondog_owner_idChanged();
    #endregion
		
		public Dog()
		{
			this._Client = default(EntityRef<Client>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_dog_id", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int dog_id
		{
			get
			{
				return this._dog_id;
			}
			set
			{
				if ((this._dog_id != value))
				{
					this.Ondog_idChanging(value);
					this.SendPropertyChanging();
					this._dog_id = value;
					this.SendPropertyChanged("dog_id");
					this.Ondog_idChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_dog_name", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string dog_name
		{
			get
			{
				return this._dog_name;
			}
			set
			{
				if ((this._dog_name != value))
				{
					this.Ondog_nameChanging(value);
					this.SendPropertyChanging();
					this._dog_name = value;
					this.SendPropertyChanged("dog_name");
					this.Ondog_nameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_dog_owner_id", DbType="Int")]
		public System.Nullable<int> dog_owner_id
		{
			get
			{
				return this._dog_owner_id;
			}
			set
			{
				if ((this._dog_owner_id != value))
				{
					if (this._Client.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.Ondog_owner_idChanging(value);
					this.SendPropertyChanging();
					this._dog_owner_id = value;
					this.SendPropertyChanged("dog_owner_id");
					this.Ondog_owner_idChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Client_Dog", Storage="_Client", ThisKey="dog_owner_id", OtherKey="client_id", IsForeignKey=true)]
		public Client Client
		{
			get
			{
				return this._Client.Entity;
			}
			set
			{
				Client previousValue = this._Client.Entity;
				if (((previousValue != value) 
							|| (this._Client.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Client.Entity = null;
						previousValue.Dogs.Remove(this);
					}
					this._Client.Entity = value;
					if ((value != null))
					{
						value.Dogs.Add(this);
						this._dog_owner_id = value.client_id;
					}
					else
					{
						this._dog_owner_id = default(Nullable<int>);
					}
					this.SendPropertyChanged("Client");
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
}
#pragma warning restore 1591
