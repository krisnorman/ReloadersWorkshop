﻿//============================================================================*
// cMainForm.LoadDataTab.cs
//
// Copyright © 2013-2014, Kevin S. Beebe
// All Rights Reserved
//============================================================================*

//============================================================================*
// .Net Using Statements
//============================================================================*

using System;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;

//============================================================================*
// Application Specific Using Statements
//============================================================================*

//============================================================================*
// NameSpace
//============================================================================*

namespace ReloadersWorkShop
	{
	//============================================================================*
	// cMainForm Class
	//============================================================================*

	partial class cMainForm
		{
		//============================================================================*
		// Private Data Members
		//============================================================================*

		private cLoadDataListView m_LoadDataListView = null;

		private bool m_fLoadDataTabInitialized = false;

		//============================================================================*
		// AddLoad()
		//============================================================================*

		private void AddLoad(cLoad Load)
			{
			//----------------------------------------------------------------------------*
			// If the Load already exists, update the existing one and exit
			//----------------------------------------------------------------------------*

			foreach (cLoad CheckLoad in m_DataFiles.LoadList)
				{
				if (CheckLoad.CompareTo(Load) == 0)
					{
					UpdateLoad(CheckLoad, Load);

					return;
					}
				}

			//----------------------------------------------------------------------------*
			// Add the new Load to the list
			//----------------------------------------------------------------------------*

			m_DataFiles.LoadList.Add(Load);

			//----------------------------------------------------------------------------*
			// Add the new Load to the LoadData tab
			//----------------------------------------------------------------------------*

			m_LoadDataListView.AddLoad(Load, LoadDataFirearmTypeCombo.Value, LoadDataCaliberCombo.SelectedIndex > 0 ? (cCaliber)LoadDataCaliberCombo.SelectedItem : null, LoadDataBulletCombo.SelectedIndex > 0 ? (cBullet)LoadDataBulletCombo.SelectedItem : null, LoadDataPowderCombo.SelectedIndex > 0 ? (cPowder)LoadDataPowderCombo.SelectedItem : null, true);

			//----------------------------------------------------------------------------*
			// Update the Load Data Tab BulletCombo
			//----------------------------------------------------------------------------*

			PopulateLoadDataCaliberCombo();

			m_LoadDataListView.Focus();
			}

		//============================================================================*
		// CreateShareFile()
		//============================================================================*

		private void CreateShareFile()
			{
			cManufacturerList ShareManufacturerList = new cManufacturerList();
			cCaliberList ShareCaliberList = new cCaliberList();
			cBulletList ShareBulletList = new cBulletList();
			cCaseList ShareCaseList = new cCaseList();
			cPowderList SharePowderList = new cPowderList();
			cPrimerList SharePrimerList = new cPrimerList();

			cLoadList ShareLoadList = new cLoadList();

			foreach (ListViewItem Item in m_LoadDataListView.CheckedItems)
				{
				cLoad Load = (cLoad)Item.Tag;

				if (Load != null)
					{
					foreach (cBulletCaliber BulletCaliber in Load.Bullet.CaliberList)
						ShareCaliberList.AddCaliber(BulletCaliber.Caliber);

					ShareManufacturerList.AddManufacturer(Load.Bullet.Manufacturer);
					ShareBulletList.AddBullet(Load.Bullet);

					ShareManufacturerList.AddManufacturer(Load.Case.Manufacturer);
					ShareCaseList.AddCase(Load.Case);

					ShareManufacturerList.AddManufacturer(Load.Powder.Manufacturer);
					SharePowderList.AddPowder(Load.Powder);

					ShareManufacturerList.AddManufacturer(Load.Primer.Manufacturer);
					SharePrimerList.AddPrimer(Load.Primer);

					ShareLoadList.Add(Load);
					}
				}

			Stream Stream = null;

			//----------------------------------------------------------------------------*
			// Save Data
			//----------------------------------------------------------------------------*

			try
				{
				SaveFileDialog FileDlg = new SaveFileDialog();

				FileDlg.Title = "Save Reloader's WorkShop Share File";
				FileDlg.AddExtension = true;
				FileDlg.DefaultExt = "rws";

				if (m_DataFiles.Preferences.ShareFilePath == null)
					FileDlg.InitialDirectory = Environment.SpecialFolder.MyDocuments.ToString();
				else
					FileDlg.InitialDirectory = m_DataFiles.Preferences.ShareFilePath;

				FileDlg.Filter = "Reloader's WorkShop Share Files (*.rws)|*.rws";
				FileDlg.CheckPathExists = true;

				DialogResult rc = FileDlg.ShowDialog();

				if (rc == DialogResult.Cancel)
					return;

				string strPath = FileDlg.FileName;

				m_DataFiles.Preferences.ShareFilePath = Path.GetDirectoryName(strPath);

				//----------------------------------------------------------------------------*
				// Open data file and create formatter
				//----------------------------------------------------------------------------*

				Stream = File.Open(strPath, FileMode.Create);

				BinaryFormatter Formatter = new BinaryFormatter();

				//----------------------------------------------------------------------------*
				// Serialize the data members
				//----------------------------------------------------------------------------*

				Formatter.Serialize(Stream, ShareManufacturerList);
				Formatter.Serialize(Stream, ShareCaliberList);
				Formatter.Serialize(Stream, ShareBulletList);
				Formatter.Serialize(Stream, ShareCaseList);
				Formatter.Serialize(Stream, SharePowderList);
				Formatter.Serialize(Stream, SharePrimerList);
				Formatter.Serialize(Stream, ShareLoadList);

				//----------------------------------------------------------------------------*
				// Close the stream
				//----------------------------------------------------------------------------*

				Stream.Close();

				Stream = null;

				MessageBox.Show("Your share file has been created successfully.  \n\nThis file can be emailed or otherwise sent to a friend who is also using Reloader's WorkShop.", "Share File Created", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
			catch (Exception e1)
				{
				MessageBox.Show(e1.Message);
				}
			finally
				{
				if (Stream != null)
					Stream.Close();
				}
			}

		//============================================================================*
		// ImportShareFile()
		//============================================================================*

		private void ImportShareFile()
			{
			cManufacturerList ShareManufacturerList = new cManufacturerList();
			cCaliberList ShareCaliberList = new cCaliberList();
			cBulletList ShareBulletList = new cBulletList();
			cCaseList ShareCaseList = new cCaseList();
			cPowderList SharePowderList = new cPowderList();
			cPrimerList SharePrimerList = new cPrimerList();

			cLoadList ShareLoadList = new cLoadList();

			Stream Stream = null;

			//----------------------------------------------------------------------------*
			// Load Data
			//----------------------------------------------------------------------------*

			try
				{
				OpenFileDialog FileDlg = new OpenFileDialog();

				FileDlg.Title = "Import Reloader's WorkShop Share File";
				FileDlg.AddExtension = true;
				FileDlg.DefaultExt = "rws";

				if (m_DataFiles.Preferences.ShareFilePath == null)
					FileDlg.InitialDirectory = Environment.SpecialFolder.MyDocuments.ToString();
				else
					FileDlg.InitialDirectory = m_DataFiles.Preferences.ShareFilePath;

				FileDlg.Filter = "Reloader's WorkShop Share Files (*.rws)|*.rws";
				FileDlg.CheckPathExists = true;

				DialogResult rc = FileDlg.ShowDialog();

				if (rc == DialogResult.Cancel)
					return;

				string strPath = FileDlg.FileName;

				m_DataFiles.Preferences.ShareFilePath = Path.GetDirectoryName(strPath);

				//----------------------------------------------------------------------------*
				// Open data file and create formatter
				//----------------------------------------------------------------------------*

				Stream = File.Open(strPath, FileMode.Open);

				BinaryFormatter Formatter = new BinaryFormatter();

				//----------------------------------------------------------------------------*
				// Deserialize the data members
				//----------------------------------------------------------------------------*

				ShareManufacturerList = (cManufacturerList)Formatter.Deserialize(Stream);
				ShareCaliberList = (cCaliberList)Formatter.Deserialize(Stream);
				ShareBulletList = (cBulletList)Formatter.Deserialize(Stream);
				ShareCaseList = (cCaseList)Formatter.Deserialize(Stream);
				SharePowderList = (cPowderList)Formatter.Deserialize(Stream);
				SharePrimerList = (cPrimerList)Formatter.Deserialize(Stream);
				ShareLoadList = (cLoadList)Formatter.Deserialize(Stream);

				//----------------------------------------------------------------------------*
				// Add the imported data to the database
				//----------------------------------------------------------------------------*

				string strMerge = "";

				strMerge += m_DataFiles.MergeManufacturers(ShareManufacturerList);

				strMerge += m_DataFiles.MergeCalibers(ShareCaliberList);

				strMerge += m_DataFiles.MergeBullets(ShareBulletList);

				strMerge += m_DataFiles.MergeCases(ShareCaseList);

				strMerge += m_DataFiles.MergePowders(SharePowderList);

				strMerge += m_DataFiles.MergePrimers(SharePrimerList);

				strMerge += m_DataFiles.MergeLoads(ShareLoadList);

				m_DataFiles.SynchDataLists();

				//----------------------------------------------------------------------------*
				// Update the Listviews
				//----------------------------------------------------------------------------*

				InitializeAllTabs();

				//----------------------------------------------------------------------------*
				// Show the import results
				//----------------------------------------------------------------------------*

				string strMessage = "The share file has been imported successfully.\n\n";

				if (strMerge.Length == 0)
					strMerge = "No new data was imported.  The share file was either empty or your data file already contained the data contained in the share file.";

				strMessage += strMerge;

				MessageBox.Show(strMessage, "Share File Imported", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
			catch
				{
				MessageBox.Show("Unable to merge share file! The file may not be a valid Reloader's WorkShop Share File.  Check with the source of the file for more information on what version of Reloader's WorkShop was used to create the file.", "Share File Import Error", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Exclamation);
				}
			finally
				{
				//----------------------------------------------------------------------------*
				// Close the stream
				//----------------------------------------------------------------------------*

				if (Stream != null)
					Stream.Close();
				}
			}

		//============================================================================*
		// InitializeLoadDataTab()
		//============================================================================*

		public void InitializeLoadDataTab()
			{
			if (!m_fLoadDataTabInitialized)
				{
				//----------------------------------------------------------------------------*
				// Load Data Tab Event Handlers
				//----------------------------------------------------------------------------*

				m_LoadDataListView = new cLoadDataListView(m_DataFiles);

				LoadDataTab.Controls.Add(m_LoadDataListView);

				LoadDataFirearmTypeCombo.SelectedIndexChanged += OnLoadDataFirearmTypeSelected;
				LoadDataCaliberCombo.SelectedIndexChanged += OnLoadDataCaliberSelected;
				LoadDataBulletCombo.SelectedIndexChanged += OnLoadDataBulletSelected;
				LoadDataPowderCombo.SelectedIndexChanged += OnLoadDataPowderSelected;

				AddLoadButton.Click += OnAddLoad;
				EditLoadButton.Click += OnEditLoad;
				ViewLoadButton.Click += OnViewLoad;
				RemoveLoadButton.Click += OnRemoveLoad;

				m_LoadDataListView.SelectedIndexChanged += OnLoadDataSelected;
				m_LoadDataListView.DoubleClick += OnLoadDataDoubleClicked;

				m_LoadDataListView.ItemChecked += OnLoadDataChecked;

				EvaluateLoadButton.Click += OnEvaluateLoad;

				ShareFileButton.Click += OnCreateShareFile;
				ImportShareFileButton.Click += OnImportShareFile;
				LoadShoppingListButton.Click += OnShoppingListClicked;

				LoadDataSelectAllButton.Click += OnLoadDataSelectAllClicked;
				LoadDataDeselectAllButton.Click += OnLoadDataDeselectAllClicked;

				m_fLoadDataTabInitialized = true;
				}

			//----------------------------------------------------------------------------*
			// Operations that are always performed
			//----------------------------------------------------------------------------*

			m_LoadDataListView.SetColumns();

			PopulateLoadDataTab();
			}

		//============================================================================*
		// OnAddLoad()
		//============================================================================*

		protected void OnAddLoad(object sender, EventArgs args)
			{
			//----------------------------------------------------------------------------*
			// Start the dialog
			//----------------------------------------------------------------------------*

			cLoadForm LoadForm = new cLoadForm(null, m_DataFiles);

			if (LoadForm.ShowDialog() == DialogResult.OK)
				{
				//----------------------------------------------------------------------------*
				// Get the new Load Data
				//----------------------------------------------------------------------------*

				cLoad NewLoad = new cLoad(LoadForm.Load);

				m_DataFiles.Preferences.LastLoad = LoadForm.Load;

				AddLoad(NewLoad);
				}

			m_LoadDataListView.Focus();
			}

		//============================================================================*
		// OnCreateSharefile()
		//============================================================================*

		protected void OnCreateShareFile(object sender, EventArgs args)
			{
			CreateShareFile();
			}

		//============================================================================*
		// OnEditLoad()
		//============================================================================*

		protected void OnEditLoad(object sender, EventArgs args)
			{
			//----------------------------------------------------------------------------*
			// Get the selected LoadData
			//----------------------------------------------------------------------------*

			ListViewItem Item = m_LoadDataListView.SelectedItems[0];

			if (Item == null)
				return;

			cLoad Load = (cLoad)Item.Tag;

			if (Load == null)
				return;

			//----------------------------------------------------------------------------*
			// Start the dialog
			//----------------------------------------------------------------------------*

			cLoadForm LoadForm = new cLoadForm(Load, m_DataFiles);

			if (LoadForm.ShowDialog() == DialogResult.OK)
				{
				//----------------------------------------------------------------------------*
				// Get the new Load Data
				//----------------------------------------------------------------------------*

				cLoad NewLoad = LoadForm.Load;

				m_DataFiles.Preferences.LastLoad = LoadForm.Load;

				UpdateLoad(Load, NewLoad);
				}

			m_LoadDataListView.Focus();
			}

		//============================================================================*
		// OnEvaluateLoad()
		//============================================================================*

		protected void OnEvaluateLoad(Object sender, EventArgs args)
			{
			cLoadList LoadList = new cLoadList();

			foreach (ListViewItem Item in m_LoadDataListView.CheckedItems)
				{
				cLoad Load = (cLoad)Item.Tag;

				LoadList.AddLoad(Load);
				}

			cLoadEvaluationForm Form = new cLoadEvaluationForm(m_DataFiles, LoadList);

			DialogResult rc = Form.ShowDialog();

			}

		//============================================================================*
		// OnImportSharefile()
		//============================================================================*

		protected void OnImportShareFile(object sender, EventArgs args)
			{
			ImportShareFile();
			}

		//============================================================================*
		// OnLoad()
		//============================================================================*

		protected void OnLoad(Object sender, EventArgs args)
			{
			if ((m_DataFiles.Preferences.MainFormLocation.X == -1 ||
				m_DataFiles.Preferences.MainFormLocation.Y == -1 ||
				m_DataFiles.Preferences.MainFormSize.Width == -1 ||
				m_DataFiles.Preferences.MainFormSize.Width == -1) &&
				!m_DataFiles.Preferences.Maximized)
				return;

			if (m_DataFiles.Preferences.Maximized)
				WindowState = FormWindowState.Maximized;
			else
				SetDesktopBounds(m_DataFiles.Preferences.MainFormLocation.X,
									m_DataFiles.Preferences.MainFormLocation.Y,
									m_DataFiles.Preferences.MainFormSize.Width,
									m_DataFiles.Preferences.MainFormSize.Height);
			}

		//============================================================================*
		// OnLoadDataBulletSelected()
		//============================================================================*

		protected void OnLoadDataBulletSelected(Object sender, EventArgs args)
			{
			if (!m_fInitialized || m_fPopulating)
				return;

			if (LoadDataBulletCombo.SelectedIndex > 0)
				m_DataFiles.Preferences.LastLoadDataBulletSelected = (cBullet)LoadDataBulletCombo.SelectedItem;
			else
				m_DataFiles.Preferences.LastLoadDataBulletSelected = null;

			PopulateLoadDataPowderCombo();
			}

		//============================================================================*
		// OnLoadDataCaliberSelected()
		//============================================================================*

		protected void OnLoadDataCaliberSelected(Object sender, EventArgs args)
			{
			if (!m_fInitialized || m_fPopulating)
				return;

			if (LoadDataCaliberCombo.SelectedIndex > 0)
				m_DataFiles.Preferences.LastLoadDataCaliberSelected = (cCaliber)LoadDataCaliberCombo.SelectedItem;
			else
				m_DataFiles.Preferences.LastLoadDataCaliberSelected = null;

			PopulateLoadDataBulletCombo();
			}

		//============================================================================*
		// OnLoadDataChecked()
		//============================================================================*

		protected void OnLoadDataChecked(object sender, ItemCheckedEventArgs args)
			{
			if (!m_fInitialized || m_fPopulating)
				return;

			(args.Item.Tag as cLoad).Checked = args.Item.Checked;

			UpdateLoadDataTabButtons();
			}

		//============================================================================*
		// OnLoadDataDeselectAllClicked()
		//============================================================================*

		protected void OnLoadDataDeselectAllClicked(object sender, EventArgs args)
			{
			for (int i = 0; i < m_LoadDataListView.Items.Count; i++)
				m_LoadDataListView.Items[i].Checked = false;

			UpdateButtons();
			}

		//============================================================================*
		// OnLoadDataDoubleClicked()
		//============================================================================*

		protected void OnLoadDataDoubleClicked(object sender, EventArgs args)
			{
			if (!m_fInitialized)
				return;

			if (m_LoadDataListView.SelectedItems.Count > 0)
				m_DataFiles.Preferences.LastLoadSelected = (cLoad)m_LoadDataListView.SelectedItems[0].Tag;

			OnEditLoad(sender, args);

			UpdateButtons();
			}

		//============================================================================*
		// OnLoadDataFirearmTypeSelected()
		//============================================================================*

		protected void OnLoadDataFirearmTypeSelected(Object sender, EventArgs args)
			{
			if (!m_fInitialized || m_fPopulating)
				return;

			m_DataFiles.Preferences.LoadDataFirearmType = LoadDataFirearmTypeCombo.Value;

			PopulateLoadDataCaliberCombo();
			}

		//============================================================================*
		// OnLoadDataPowderSelected()
		//============================================================================*

		protected void OnLoadDataPowderSelected(Object sender, EventArgs args)
			{
			if (!m_fInitialized || m_fPopulating)
				return;

			if (LoadDataPowderCombo.SelectedIndex > 0)
				m_DataFiles.Preferences.LastLoadDataPowderSelected = (cPowder)LoadDataPowderCombo.SelectedItem;
			else
				m_DataFiles.Preferences.LastLoadDataPowderSelected = null;

			PopulateLoadDataListView();
			}

		//============================================================================*
		// OnLoadDataSelectAllClicked()
		//============================================================================*

		protected void OnLoadDataSelectAllClicked(object sender, EventArgs args)
			{
			for (int i = 0; i < m_LoadDataListView.Items.Count; i++)
				m_LoadDataListView.Items[i].Checked = true;

			UpdateButtons();
			}

		//============================================================================*
		// OnLoadDataSelected()
		//============================================================================*

		protected void OnLoadDataSelected(object sender, EventArgs args)
			{
			if (!m_fInitialized || m_LoadDataListView.Populating)
				return;

			if (m_LoadDataListView.SelectedItems.Count > 0)
				m_DataFiles.Preferences.LastLoadSelected = (cLoad)m_LoadDataListView.SelectedItems[0].Tag;

			UpdateLoadDataTabButtons();
			}

		//============================================================================*
		// OnRemoveLoad()
		//============================================================================*

		protected void OnRemoveLoad(object sender, EventArgs args)
			{
			cLoad Load = null;

			ListViewItem Item = m_LoadDataListView.SelectedItems[0];

			if (Item != null)
				Load = (cLoad)Item.Tag;

			if (Load == null)
				{
				m_LoadDataListView.Focus();

				return;
				}

			//----------------------------------------------------------------------------*
			// See if the Load is being used in other records
			//----------------------------------------------------------------------------*

			string strCount = m_DataFiles.DeleteLoad(Load, true);

			if (strCount.Length > 0)
				{
				string strMessage = "This load is used in\n\n";
				strMessage += strCount;
				strMessage += "\nThe above item(s) must be removed in order to remove this load.";

				MessageBox.Show(this, strMessage, "Load in Use", MessageBoxButtons.OK, MessageBoxIcon.Information);

				m_LoadDataListView.Focus();

				return;
				}

			//----------------------------------------------------------------------------*
			// Make sure the user is sure
			//----------------------------------------------------------------------------*

			if (MessageBox.Show(this, "Are you sure you wish to remove this load data?", "Data Deletion Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
				{
				m_DataFiles.DeleteLoad(Load);

				m_LoadDataListView.Items.Remove(Item);

				UpdateButtons();
				}

			m_LoadDataListView.Focus();
			}

		//============================================================================*
		// OnShoppingListClicked()
		//============================================================================*

		protected void OnShoppingListClicked(object sender, EventArgs args)
			{
			//----------------------------------------------------------------------------*
			// Show the dialog
			//----------------------------------------------------------------------------*

			cLoadShoppingListPreviewDialog ShoppingListDialog = new cLoadShoppingListPreviewDialog(m_DataFiles);

			ShoppingListDialog.ShowDialog();
			}

		//============================================================================*
		// OnViewLoad()
		//============================================================================*

		protected void OnViewLoad(object sender, EventArgs args)
			{
			//----------------------------------------------------------------------------*
			// Get the selected load
			//----------------------------------------------------------------------------*

			if (m_LoadDataListView.SelectedItems.Count == 0)
				return;

			ListViewItem Item = m_LoadDataListView.SelectedItems[0];

			if (Item == null)
				return;

			cLoad Load = (cLoad)Item.Tag;

			if (Load == null)
				return;

			//----------------------------------------------------------------------------*
			// Start the dialog
			//----------------------------------------------------------------------------*

			cLoadForm LoadForm = new cLoadForm(Load, m_DataFiles, true);

			LoadForm.ShowDialog();

			m_LoadDataListView.Focus();
			}

		//============================================================================*
		// PopulateLoadDataBulletCombo()
		//============================================================================*

		private void PopulateLoadDataBulletCombo()
			{
			m_fPopulating = true;

			LoadDataBulletCombo.Items.Clear();

			cCaliber Caliber = null;

			if (LoadDataCaliberCombo.SelectedIndex > 0)
				Caliber = (cCaliber)LoadDataCaliberCombo.SelectedItem;

			LoadDataBulletCombo.Items.Add("Any Bullet");

			cBullet SelectBullet = null;

			foreach (cBullet CheckBullet in m_DataFiles.BulletList)
				{
				if (CheckBullet.FirearmType == LoadDataFirearmTypeCombo.Value &&
					(Caliber == null || CheckBullet.HasCaliber(Caliber)))
					{
					bool fOK = false;

					foreach (cLoad CheckLoad in m_DataFiles.LoadList)
						{
						if (CheckLoad.Bullet.Equals(CheckBullet))
							{
							fOK = true;

							break;
							}
						}

					if (fOK)
						{
						bool fBulletUsed = false;

						foreach (cLoad Load in m_DataFiles.LoadList)
							{
							if (Load.Bullet.CompareTo(CheckBullet) == 0)
								{
								fBulletUsed = true;

								break;
								}
							}

						fOK = fBulletUsed;
						}

					if (fOK)
						{
						LoadDataBulletCombo.Items.Add(CheckBullet);

						if (CheckBullet.CompareTo(m_DataFiles.Preferences.LastLoadDataBulletSelected) == 0)
							SelectBullet = CheckBullet;
						}
					}
				}

			if (SelectBullet != null)
				LoadDataBulletCombo.SelectedItem = SelectBullet;
			else
				{
				if (LoadDataBulletCombo.Items.Count > 0)
					LoadDataBulletCombo.SelectedIndex = 0;
				}

			m_fPopulating = false;

			PopulateLoadDataPowderCombo();
			}

		//============================================================================*
		// PopulateLoadDataCaliberCombo()
		//============================================================================*

		private void PopulateLoadDataCaliberCombo()
			{
			m_fPopulating = true;

			LoadDataCaliberCombo.Items.Clear();

			LoadDataCaliberCombo.Items.Add("Any Caliber");

			cCaliber SelectCaliber = null;

			foreach (cCaliber CheckCaliber in m_DataFiles.CaliberList)
				{
				if (CheckCaliber.FirearmType == LoadDataFirearmTypeCombo.Value)
					{
					bool fCaliberUsed = false;

					foreach (cLoad Load in m_DataFiles.LoadList)
						{
						if (CheckCaliber.Equals(Load.Caliber))
							{
							fCaliberUsed = true;

							break;
							}
						}

					if (fCaliberUsed)
						{
						LoadDataCaliberCombo.Items.Add(CheckCaliber);

						if (CheckCaliber.CompareTo(m_DataFiles.Preferences.LastLoadDataCaliberSelected) == 0)
							SelectCaliber = CheckCaliber;
						}
					}
				}

			if (SelectCaliber != null)
				LoadDataCaliberCombo.SelectedItem = SelectCaliber;
			else
				{
				if (LoadDataCaliberCombo.Items.Count > 0)
					LoadDataCaliberCombo.SelectedIndex = 0;
				}

			m_fPopulating = false;

			PopulateLoadDataBulletCombo();
			}

		//============================================================================*
		// PopulateLoadDataListView()
		//============================================================================*

		public void PopulateLoadDataListView()
			{
			m_LoadDataListView.Populate(LoadDataFirearmTypeCombo.Value,
										LoadDataCaliberCombo.SelectedIndex > 0 ? (LoadDataCaliberCombo.SelectedItem as cCaliber) : null,
										LoadDataBulletCombo.SelectedIndex > 0 ? (LoadDataBulletCombo.SelectedItem as cBullet) : null,
										LoadDataPowderCombo.SelectedIndex > 0 ? (LoadDataPowderCombo.SelectedItem as cPowder) : null);

			UpdateLoadDataTabButtons();
			}


		//============================================================================*
		// PopulateLoadDataListViewColumns()
		//============================================================================*

		public void PopulateLoadDataListViewColumns()
			{
			m_LoadDataListView.SetColumns();

			PopulateLoadDataListView();
			}

		//============================================================================*
		// PopulateLoadDataPowderCombo()
		//============================================================================*

		private void PopulateLoadDataPowderCombo()
			{
			m_fPopulating = true;

			LoadDataPowderCombo.Items.Clear();

			cPowder SelectPowder = null;

			cBullet Bullet = null;

			if (LoadDataBulletCombo.SelectedIndex > 0)
				Bullet = (cBullet)LoadDataBulletCombo.SelectedItem;

			cCaliber Caliber = null;

			if (LoadDataCaliberCombo.SelectedIndex > 0)
				Caliber = (cCaliber)LoadDataCaliberCombo.SelectedItem;

			LoadDataPowderCombo.Items.Add("Any Powder");

			foreach (cPowder CheckPowder in m_DataFiles.PowderList)
				{
				if ((LoadDataFirearmTypeCombo.Value == cFirearm.eFireArmType.None || CheckPowder.FirearmType == LoadDataFirearmTypeCombo.Value))
					{
					bool fPowderUsed = false;

					foreach (cLoad Load in m_DataFiles.LoadList)
						{
						if (Load.Powder.Equals(CheckPowder) &&
							(Bullet == null || Load.Bullet.CompareTo(Bullet) == 0) &&
							(Caliber == null || Load.Caliber.CompareTo(Caliber) == 0))
							{
							fPowderUsed = true;

							break;
							}
						}

					if (fPowderUsed)
						{
						LoadDataPowderCombo.Items.Add(CheckPowder);

						if (CheckPowder.CompareTo(m_DataFiles.Preferences.LastLoadDataPowderSelected) == 0)
							SelectPowder = CheckPowder;
						}
					}
				}

			if (SelectPowder != null)
				LoadDataPowderCombo.SelectedItem = SelectPowder;
			else
				{
				if (LoadDataPowderCombo.Items.Count > 0)
					LoadDataPowderCombo.SelectedIndex = 0;
				}

			m_fPopulating = false;

			PopulateLoadDataListView();
			}

		//============================================================================*
		// PopulateLoadDataTab()
		//============================================================================*

		private void PopulateLoadDataTab()
			{
			m_fPopulating = true;

			//----------------------------------------------------------------------------*
			// Initialize FirearmTypeCombo
			//----------------------------------------------------------------------------*

			LoadDataFirearmTypeCombo.Value = m_DataFiles.Preferences.LoadDataFirearmType;

			//----------------------------------------------------------------------------*
			// Combos and m_LoadDataListView
			//----------------------------------------------------------------------------*

			m_fPopulating = false;

			PopulateLoadDataCaliberCombo();
			}

		//============================================================================*
		// UpdateLoad()
		//============================================================================*

		private void UpdateLoad(cLoad OldLoad, cLoad NewLoad)
			{
			//----------------------------------------------------------------------------*
			// Find the NewLoad
			//----------------------------------------------------------------------------*

			foreach (cLoad CheckLoad in m_DataFiles.LoadList)
				{
				//----------------------------------------------------------------------------*
				// See if this is the same Load
				//----------------------------------------------------------------------------*

				if (CheckLoad.CompareTo(OldLoad) == 0)
					{
					//----------------------------------------------------------------------------*
					// Update the current NewLoad record
					//----------------------------------------------------------------------------*

					CheckLoad.FirearmType = NewLoad.FirearmType;
					CheckLoad.Caliber = NewLoad.Caliber;
					CheckLoad.Bullet = NewLoad.Bullet;
					CheckLoad.Powder = NewLoad.Powder;
					CheckLoad.Case = NewLoad.Case;
					CheckLoad.Primer = NewLoad.Primer;
					CheckLoad.ChargeList = new cChargeList(NewLoad.ChargeList);

					//----------------------------------------------------------------------------*
					// Update the New Load on the LoadData tab
					//----------------------------------------------------------------------------*

					m_LoadDataListView.UpdateLoad(CheckLoad, LoadDataFirearmTypeCombo.Value, LoadDataCaliberCombo.SelectedIndex > 0 ? (cCaliber)LoadDataCaliberCombo.SelectedItem : null, LoadDataBulletCombo.SelectedIndex > 0 ? (cBullet)LoadDataBulletCombo.SelectedItem : null, LoadDataPowderCombo.SelectedIndex > 0 ? (cPowder)LoadDataPowderCombo.SelectedItem : null, true);

					//----------------------------------------------------------------------------*
					// Update the tab data
					//----------------------------------------------------------------------------*

					PopulateBatchListView();

					return;
					}
				}

			//----------------------------------------------------------------------------*
			// If the NewLoad was not found, add it
			//----------------------------------------------------------------------------*

			AddLoad(NewLoad);
			}

		//============================================================================*
		// UpdateLoadDataTabButtons()
		//============================================================================*

		private void UpdateLoadDataTabButtons()
			{
			//----------------------------------------------------------------------------*
			// Edit, View, Remove Buttons
			//----------------------------------------------------------------------------*

			EditLoadButton.Enabled = m_LoadDataListView.SelectedItems.Count > 0;
			ViewLoadButton.Enabled = m_LoadDataListView.SelectedItems.Count > 0;
			RemoveLoadButton.Enabled = m_LoadDataListView.SelectedItems.Count > 0;

			//----------------------------------------------------------------------------*
			// Evaluate Button
			//----------------------------------------------------------------------------*

			int nTestCount = 0;

			if (m_LoadDataListView.CheckedCount > 0)
				{
				foreach (ListViewItem Item in m_LoadDataListView.CheckedItems)
					{
					cLoad Load = (cLoad)Item.Tag;

					foreach (cCharge Charge in Load.ChargeList)
						{
						foreach (cChargeTest ChargeTest in Charge.TestList)
							{
							if (ChargeTest.BatchID != 0)
								nTestCount++;
							}
						}
					}

				EvaluateLoadButton.Enabled = nTestCount > 1;
				}
			else
				EvaluateLoadButton.Enabled = false;

			//----------------------------------------------------------------------------*
			// Shopping List, share, and email buttons
			//----------------------------------------------------------------------------*

			LoadShoppingListButton.Enabled = m_LoadDataListView.CheckedCount > 0;

			ShareFileButton.Enabled = m_LoadDataListView.CheckedItems.Count > 0;
			}
		}
	}