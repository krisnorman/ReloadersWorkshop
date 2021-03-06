﻿using System;
using System.Drawing;
using System.Xml;
using System.Windows.Forms;

namespace ReloadersWorkShop.Preferences
	{
	public partial class cPreferences
		{
		//============================================================================*
		// Export()
		//============================================================================*

		public void Export(cRWXMLDocument XMLDocument, XmlElement XMLParentElement)
			{
			XmlElement XMLThisElement = XMLDocument.CreateElement("Preferences");
			XMLParentElement.AppendChild(XMLThisElement);

			//----------------------------------------------------------------------------*
			// Measurements Settings
			//----------------------------------------------------------------------------*

			XMLDocument.CreateElement("MetricBulletWeights", m_fMetricBulletWeights, XMLThisElement);
			XMLDocument.CreateElement("MetricCanWeights", m_fMetricCanWeights, XMLThisElement);
			XMLDocument.CreateElement("MetricDimensions", m_fMetricDimensions, XMLThisElement);
			XMLDocument.CreateElement("MetricFirearms", m_fMetricFirearms, XMLThisElement);
			XMLDocument.CreateElement("MetricGroups", m_fMetricGroups, XMLThisElement);
			XMLDocument.CreateElement("MetricPowderWeights", m_fMetricPowderWeights, XMLThisElement);
			XMLDocument.CreateElement("MetricRanges", m_fMetricRanges, XMLThisElement);
			XMLDocument.CreateElement("MetricShotWeights", m_fMetricShotWeights, XMLThisElement);
			XMLDocument.CreateElement("MetricVelocities", m_fMetricVelocities, XMLThisElement);

			//----------------------------------------------------------------------------*
			// Inventory system
			//----------------------------------------------------------------------------*

			XMLDocument.CreateElement("TrackInventory", m_fTrackInventory, XMLThisElement);

			XMLDocument.CreateElement("strCurrency", m_strCurrency, XMLThisElement);
			XMLDocument.CreateElement("TrackReloads", m_fTrackReloads, XMLThisElement);
			XMLDocument.CreateElement("UseLastPurchase", m_fUseLastPurchase, XMLThisElement);
			XMLDocument.CreateElement("IncludeTaxShipping", m_fIncludeTaxShipping, XMLThisElement);
			XMLDocument.CreateElement("TaxRate", m_dTaxRate, XMLThisElement);

			//----------------------------------------------------------------------------*
			// Atmospheric Settings
			//----------------------------------------------------------------------------*

			XMLDocument.CreateElement("MetricAltitudes", m_fMetricAltitudes, XMLThisElement);
			XMLDocument.CreateElement("MetricPressures", m_fMetricPressures, XMLThisElement);
			XMLDocument.CreateElement("MetricTemperatures", m_fMetricTemperatures, XMLThisElement);

			//----------------------------------------------------------------------------*
			// Decimals
			//----------------------------------------------------------------------------*

			XMLDocument.CreateElement("BulletWeightDecimals", m_nBulletWeightDecimals, XMLThisElement);
			XMLDocument.CreateElement("CanWeightDecimals", m_nCanWeightDecimals, XMLThisElement);
			XMLDocument.CreateElement("DimensionDecimals", m_nDimensionDecimals, XMLThisElement);
			XMLDocument.CreateElement("FirearmDecimals", m_nFirearmDecimals, XMLThisElement);
			XMLDocument.CreateElement("GroupDecimals", m_nGroupDecimals, XMLThisElement);
			XMLDocument.CreateElement("PowderWeightDecimals", m_nPowderWeightDecimals, XMLThisElement);
			XMLDocument.CreateElement("ShotWeightDecimals", m_nShotWeightDecimals, XMLThisElement);

			//----------------------------------------------------------------------------*
			// Window sizes and locations
			//----------------------------------------------------------------------------*

			XMLDocument.CreateElement("Maximized", m_fMaximized, XMLThisElement);

			XMLDocument.CreateElement("MainFormLocation", m_MainFormLocation, XMLThisElement);
			XMLDocument.CreateElement("MainFormSize", m_MainFormSize, XMLThisElement);

			XMLDocument.CreateElement("LastMainTabSelected", m_strLastMainTabSelected, XMLThisElement);

			//----------------------------------------------------------------------------*
			// Ammo Tab Settings
			//----------------------------------------------------------------------------*

			XMLDocument.CreateElement("AmmoNonZeroFilter", m_fAmmoNonZeroFilter, XMLThisElement);
			XMLDocument.CreateElement("AmmoMinStockFilter", m_fAmmoMinStockFilter, XMLThisElement);
			XMLDocument.CreateElement("AmmoFactoryFilter", m_fAmmoFactoryFilter, XMLThisElement);
			XMLDocument.CreateElement("AmmoFactoryReloadFilter", m_fAmmoFactoryReloadFilter, XMLThisElement);
			XMLDocument.CreateElement("AmmoMyReloadFilter", m_fAmmoMyReloadFilter, XMLThisElement);

			XMLDocument.CreateElement("AmmoSortColumn", m_nAmmoSortColumn, XMLThisElement);
			XMLDocument.CreateElement("AmmoSortOrder", m_AmmoSortOrder, XMLThisElement);

			XMLDocument.CreateElement("ReloadKeepDays", m_nReloadKeepDays, XMLThisElement);

			//----------------------------------------------------------------------------*
			// Backup Settings
			//----------------------------------------------------------------------------*

			XMLDocument.CreateElement("BackupOK", m_fBackupOK, XMLThisElement);
			XMLDocument.CreateElement("AutoBackup", m_fAutoBackup, XMLThisElement);
			XMLDocument.CreateElement("BackupFolder", m_strBackupFolder, XMLThisElement);
			XMLDocument.CreateElement("AutoSaveTime", m_nAutoSaveTime, XMLThisElement);
			XMLDocument.CreateElement("BackupKeepDays", m_nBackupKeepDays, XMLThisElement);

			//----------------------------------------------------------------------------*
			// Ballistics Tab Settings
			//----------------------------------------------------------------------------*

			XMLDocument.CreateElement("ShowApexMarker", m_fShowApexMarker, XMLThisElement);
			XMLDocument.CreateElement("ShowDropChartRangeMarkers", m_fShowDropChartRangeMarkers, XMLThisElement);
			XMLDocument.CreateElement("ShowGroundStrikeMarkers", m_fShowGroundStrikeMarkers, XMLThisElement);
			XMLDocument.CreateElement("ShowTransonicMarkers", m_fShowTransonicMarkers, XMLThisElement);
			XMLDocument.CreateElement("ShowWindDriftRangeMarkers", m_fShowWindDriftRangeMarkers, XMLThisElement);
			XMLDocument.CreateElement("BallisticsUseSF", m_fBallisticsUseSF, XMLThisElement);

			//----------------------------------------------------------------------------*
			// Batch Load List
			//----------------------------------------------------------------------------*

			XMLDocument.CreateElement("BatchLoadSortColumn", m_nBatchLoadSortColumn, XMLThisElement);
			XMLDocument.CreateElement("BatchLoadSortOrder", m_BatchLoadSortOrder, XMLThisElement);

			//----------------------------------------------------------------------------*
			// Batch Print Form Settings
			//----------------------------------------------------------------------------*

			XMLDocument.CreateElement("BatchPrintPaper", m_nBatchPrintPaper, XMLThisElement);
			XMLDocument.CreateElement("BatchPrintStartLabel", m_nBatchPrintStartLabel, XMLThisElement);

			//----------------------------------------------------------------------------*
			// Bullet Caliber List settings
			//----------------------------------------------------------------------------*

			XMLDocument.CreateElement("BulletCaliberSortColumn", m_nBulletCaliberSortColumn, XMLThisElement);
			XMLDocument.CreateElement("BulletCaliberSortOrder", m_BulletCaliberSortOrder, XMLThisElement);

			//----------------------------------------------------------------------------*
			// Bullet Supply List settings
			//----------------------------------------------------------------------------*

			XMLDocument.CreateElement("BulletSortColumn", m_nBulletSortColumn, XMLThisElement);
			XMLDocument.CreateElement("BulletSortOrder", m_BulletSortOrder, XMLThisElement);

			//----------------------------------------------------------------------------*
			// Caliber List Settings
			//----------------------------------------------------------------------------*

			XMLDocument.CreateElement("CaliberSortColumn", m_nCaliberSortColumn, XMLThisElement);
			XMLDocument.CreateElement("CaliberSortOrder", m_CaliberSortOrder, XMLThisElement);

			//----------------------------------------------------------------------------*
			// Case Supply List Settings
			//----------------------------------------------------------------------------*

			XMLDocument.CreateElement("CaseSortColumn", m_nCaseSortColumn, XMLThisElement);
			XMLDocument.CreateElement("CaseSortOrder", m_CaseSortOrder, XMLThisElement);

			//----------------------------------------------------------------------------*
			// Charge List Settings
			//----------------------------------------------------------------------------*

			XMLDocument.CreateElement("ChargeSortColumn", m_nChargeSortColumn, XMLThisElement);
			XMLDocument.CreateElement("ChargeSortOrder", m_ChargeSortOrder, XMLThisElement);

			//----------------------------------------------------------------------------*
			// Charge Test List Settings
			//----------------------------------------------------------------------------*

			XMLDocument.CreateElement("ChargeTestSortColumn", m_nChargeTestSortColumn, XMLThisElement);
			XMLDocument.CreateElement("ChargeTestSortOrder", m_ChargeTestSortOrder, XMLThisElement);

			//----------------------------------------------------------------------------*
			// Conversion Calculator
			//----------------------------------------------------------------------------*

			XMLDocument.CreateElement("ConversionDecimals", m_nConversionDecimals, XMLThisElement);

			//----------------------------------------------------------------------------*
			// Copy Charge Form Settings
			//----------------------------------------------------------------------------*

			XMLDocument.CreateElement("CopyChargeSortColumn", m_nCopyChargeSortColumn, XMLThisElement);
			XMLDocument.CreateElement("CopyChargeSortOrder", m_CopyChargeSortOrder, XMLThisElement);

			//----------------------------------------------------------------------------*
			// Data Entry settings
			//----------------------------------------------------------------------------*

			XMLDocument.CreateElement("AutoCheck", m_fAutoCheck, XMLThisElement);
			XMLDocument.CreateElement("AutoCheckNonZero", m_fAutoCheckNonZero, XMLThisElement);
			XMLDocument.CreateElement("ToolTips", m_fToolTips, XMLThisElement);
			XMLDocument.CreateElement("ShowArchivedBatches", m_fShowArchivedBatches, XMLThisElement);

			//----------------------------------------------------------------------------*
			// Evaluation List Settings
			//----------------------------------------------------------------------------*

			XMLDocument.CreateElement("EvaluationSortColumn", m_nEvaluationSortColumn, XMLThisElement);
			XMLDocument.CreateElement("EvaluationSortOrder", m_EvaluationSortOrder, XMLThisElement);

			//----------------------------------------------------------------------------*
			// Firearm Tab Settings
			//----------------------------------------------------------------------------*

			XMLDocument.CreateElement("FirearmAccessoryBipodFilter", m_fFirearmAccessoryBipodFilter, XMLThisElement);
			XMLDocument.CreateElement("FirearmAccessoryFurnitureFilter", m_fFirearmAccessoryFurnitureFilter, XMLThisElement);
			XMLDocument.CreateElement("FirearmAccessoryLaserFilter", m_fFirearmAccessoryLaserFilter, XMLThisElement);
			XMLDocument.CreateElement("FirearmAccessoryLightFilter", m_fFirearmAccessoryLightFilter, XMLThisElement);
			XMLDocument.CreateElement("FirearmAccessoryMagnifierFilter", m_fFirearmAccessoryMagnifierFilter, XMLThisElement);
			XMLDocument.CreateElement("FirearmAccessoryOtherFilter", m_fFirearmAccessoryOtherFilter, XMLThisElement);
			XMLDocument.CreateElement("FirearmAccessoryPartsFilter", m_fFirearmAccessoryPartsFilter, XMLThisElement);
			XMLDocument.CreateElement("FirearmAccessoryRedDotFilter", m_fFirearmAccessoryRedDotFilter, XMLThisElement);
			XMLDocument.CreateElement("FirearmAccessoryScopeFilter", m_fFirearmAccessoryScopeFilter, XMLThisElement);
			XMLDocument.CreateElement("FirearmAccessoryShowAll", m_fFirearmAccessoryShowAll, XMLThisElement);
			XMLDocument.CreateElement("FirearmAccessoryShowGroups", m_fFirearmAccessoryShowGroups, XMLThisElement);
			XMLDocument.CreateElement("FirearmAccessoryTriggerFilter", m_fFirearmAccessoryTriggerFilter, XMLThisElement);

			//----------------------------------------------------------------------------*
			// Firearm Form Settings
			//----------------------------------------------------------------------------*

			XMLDocument.CreateElement("FirearmBulletSortColumn", m_nFirearmBulletSortColumn, XMLThisElement);
			XMLDocument.CreateElement("FirearmBulletSortOrder", m_FirearmBulletSortOrder, XMLThisElement);

			//----------------------------------------------------------------------------*
			// Firearm Image Settings
			//----------------------------------------------------------------------------*

			XMLDocument.CreateElement("FirearmImagePath", m_strFirearmImagePath, XMLThisElement);

			//----------------------------------------------------------------------------*
			// Firearm List Settings
			//----------------------------------------------------------------------------*

			XMLDocument.CreateElement("FirearmPrintAll", m_fFirearmPrintAll, XMLThisElement);
			XMLDocument.CreateElement("FirearmPrintDetail", m_fFirearmPrintDetail, XMLThisElement);
			XMLDocument.CreateElement("FirearmPrintSpecs", m_fFirearmPrintSpecs, XMLThisElement);
			XMLDocument.CreateElement("FirearmSortColumn", m_nFirearmSortColumn, XMLThisElement);
			XMLDocument.CreateElement("FirearmSortOrder", m_FirearmSortOrder, XMLThisElement);

			//----------------------------------------------------------------------------*
			// Hide Unchecked Button States
			//----------------------------------------------------------------------------*

			XMLDocument.CreateElement("HideUncheckedCalibers", m_fHideUncheckedCalibers, XMLThisElement);
			XMLDocument.CreateElement("HideUncheckedSupplies", m_fHideUncheckedSupplies, XMLThisElement);

			//----------------------------------------------------------------------------*
			// Inventory Activity Settings
			//----------------------------------------------------------------------------*

			XMLDocument.CreateElement("LastActivityType", m_eLastActivityType, XMLThisElement);
			XMLDocument.CreateElement("LastPurchaseSource", m_strLastPurchaseSource, XMLThisElement);
			XMLDocument.CreateElement("LastAddStockReason", m_strLastAddStockReason, XMLThisElement);
			XMLDocument.CreateElement("LastReduceStockReason", m_strLastReduceStockReason, XMLThisElement);
			XMLDocument.CreateElement("LastFiredLocation", m_strLastFiredLocation, XMLThisElement);
			XMLDocument.CreateElement("ShowBatchTransactions", m_fShowBatchTransactions, XMLThisElement);
			XMLDocument.CreateElement("ShowArchivedTransactions", m_fShowArchivedTransactions, XMLThisElement);

			//----------------------------------------------------------------------------*
			// Inventory Group Settings
			//----------------------------------------------------------------------------*

			XMLDocument.CreateElement("Currency", m_strCurrency, XMLThisElement);
			XMLDocument.CreateElement("TrackReloads", m_fTrackReloads, XMLThisElement);
			XMLDocument.CreateElement("UseLastPurchase", m_fUseLastPurchase, XMLThisElement);
			XMLDocument.CreateElement("IncludeTaxShipping", m_fIncludeTaxShipping, XMLThisElement);
			XMLDocument.CreateElement("TaxRate", m_dTaxRate, XMLThisElement);

			//----------------------------------------------------------------------------*
			// Load Data List Settings
			//----------------------------------------------------------------------------*

			XMLDocument.CreateElement("LoadDataSortColumn", m_nLoadDataSortColumn, XMLThisElement);
			XMLDocument.CreateElement("LoadDataSortOrder", m_LoadDataSortOrder, XMLThisElement);

			//----------------------------------------------------------------------------*
			// Manufcturer List Settings
			//----------------------------------------------------------------------------*

			XMLDocument.CreateElement("ManufacturerSortColumn", m_nManufacturerSortColumn, XMLThisElement);
			XMLDocument.CreateElement("ManufacturerSortOrder", m_ManufacturerSortOrder, XMLThisElement);

			//----------------------------------------------------------------------------*
			// Powder Supply List Settings
			//----------------------------------------------------------------------------*

			XMLDocument.CreateElement("PowderSortColumn", m_nPowderSortColumn, XMLThisElement);
			XMLDocument.CreateElement("PowderSortOrder", m_PowderSortOrder, XMLThisElement);

			//----------------------------------------------------------------------------*
			// Primer Supply List Settings
			//----------------------------------------------------------------------------*

			XMLDocument.CreateElement("PrimerSortColumn", m_nPrimerSortColumn, XMLThisElement);
			XMLDocument.CreateElement("PrimerSortOrder", m_PrimerSortOrder, XMLThisElement);

			//----------------------------------------------------------------------------*
			// Supply Tab Settings
			//----------------------------------------------------------------------------*

			XMLDocument.CreateElement("LastSupplyTypeSelected", m_eLastSupplyTypeSelected, XMLThisElement);
			XMLDocument.CreateElement("SupplyPrintAll", m_fSupplyPrintAll, XMLThisElement);
			XMLDocument.CreateElement("SupplyPrintChecked", m_fSupplyPrintChecked, XMLThisElement);
			XMLDocument.CreateElement("SupplyPrintNonZero", m_fSupplyPrintNonZero, XMLThisElement);
			XMLDocument.CreateElement("SupplyPrintBelowStock", m_fSupplyPrintBelowStock, XMLThisElement);

			//----------------------------------------------------------------------------*
			// Target Calculator Colors
			//----------------------------------------------------------------------------*

			XMLDocument.CreateElement("TargetAimPointColor", m_TargetAimPointColor, XMLThisElement);
			XMLDocument.CreateElement("TargetExtremesColor", m_TargetExtremesColor, XMLThisElement);
			XMLDocument.CreateElement("TargetGroupBoxColor", m_TargetGroupBoxColor, XMLThisElement);
			XMLDocument.CreateElement("TargetOffsetColor", m_TargetOffsetColor, XMLThisElement);
			XMLDocument.CreateElement("TargetReticleColor", m_TargetReticleColor, XMLThisElement);
			XMLDocument.CreateElement("TargetScaleBackcolor", m_TargetScaleBackcolor, XMLThisElement);
			XMLDocument.CreateElement("TargetScaleForecolor", m_TargetScaleForecolor, XMLThisElement);
			XMLDocument.CreateElement("TargetShotColor", m_TargetShotColor, XMLThisElement);
			XMLDocument.CreateElement("TargetShotForecolor", m_TargetShotForecolor, XMLThisElement);

			//----------------------------------------------------------------------------*
			// Target Calculator Settings
			//----------------------------------------------------------------------------*

			XMLDocument.CreateElement("TargetShowBoxesSet", m_fTargetShowBoxesSet, XMLThisElement);
			XMLDocument.CreateElement("TargetShowAimPoint", m_fTargetShowAimPoint, XMLThisElement);
			XMLDocument.CreateElement("TargetShowExtremes", m_fTargetShowExtremes, XMLThisElement);
			XMLDocument.CreateElement("TargetShowGroupBox", m_fTargetShowGroupBox, XMLThisElement);
			XMLDocument.CreateElement("TargetShowOffset", m_fTargetShowOffset, XMLThisElement);
			XMLDocument.CreateElement("TargetShowScale", m_fTargetShowScale, XMLThisElement);
			XMLDocument.CreateElement("TargetShowShotNum", m_fTargetShowShotNum, XMLThisElement);

			//----------------------------------------------------------------------------*
			// Transaction List Settings
			//----------------------------------------------------------------------------*

			XMLDocument.CreateElement("TransactionSortColumn", m_nTransactionSortColumn, XMLThisElement);
			XMLDocument.CreateElement("TransactionSortOrder", m_TransactionSortOrder, XMLThisElement);
			}

		//============================================================================*
		// Import()
		//============================================================================*

		public bool Import(cRWXMLDocument XMLDocument, XmlNode XMLThisNode, bool fCountOnly = false)
			{
			XmlNode XMLNode = XMLThisNode.FirstChild;

			while (XMLNode != null)
				{
				switch (XMLNode.Name)
					{
					//----------------------------------------------------------------------------*
					// Measurements Settings
					//----------------------------------------------------------------------------*

					case "MetricBulletWeights":
						if (!fCountOnly)
							XMLDocument.Import(XMLNode, out m_fMetricBulletWeights);
						break;
					case "MetricCanWeights":
						if (!fCountOnly)
							XMLDocument.Import(XMLNode, out m_fMetricCanWeights);
						break;
					case "MetricDimensions":
						if (!fCountOnly)
							XMLDocument.Import(XMLNode, out m_fMetricDimensions);
						break;
					case "MetricFirearms":
						if (!fCountOnly)
							XMLDocument.Import(XMLNode, out m_fMetricFirearms);
						break;
					case "MetricGroups":
						if (!fCountOnly)
							XMLDocument.Import(XMLNode, out m_fMetricGroups);
						break;
					case "MetricPowderWeights":
						if (!fCountOnly)
							XMLDocument.Import(XMLNode, out m_fMetricPowderWeights);
						break;
					case "MetricRanges":
						if (!fCountOnly)
							XMLDocument.Import(XMLNode, out m_fMetricRanges);
						break;
					case "MetricShotWeights":
						if (!fCountOnly)
							XMLDocument.Import(XMLNode, out m_fMetricShotWeights);
						break;
					case "MetricVelocities":
						if (!fCountOnly)
							XMLDocument.Import(XMLNode, out m_fMetricVelocities);
						break;

					//----------------------------------------------------------------------------*
					// Inventory system
					//----------------------------------------------------------------------------*

					case "TrackInventory":
						bool fTrackInventory = false;

						XMLDocument.Import(XMLNode, out fTrackInventory);

						XMLDocument.TrackInventory = fTrackInventory;

						if (!fCountOnly)
							m_fTrackInventory = fTrackInventory;

						break;
					case "Currency":
						if (!fCountOnly)
							XMLDocument.Import(XMLNode, out m_strCurrency);
						break;
					case "TrackReloads":
						if (!fCountOnly)
							XMLDocument.Import(XMLNode, out m_fTrackReloads);
						break;
					case "ReloadKeepDays":
						if (!fCountOnly)
							XMLDocument.Import(XMLNode, out m_nReloadKeepDays);
						break;
					case "UseLastPurchase":
						if (!fCountOnly)
							XMLDocument.Import(XMLNode, out m_fUseLastPurchase);
						break;
					case "IncludeTaxShipping":
						if (!fCountOnly)
							XMLDocument.Import(XMLNode, out m_fIncludeTaxShipping);
						break;
					case "TaxRate":
						if (!fCountOnly)
							XMLDocument.Import(XMLNode, out m_dTaxRate);
						break;

					//----------------------------------------------------------------------------*
					// Atmospheric Settings
					//----------------------------------------------------------------------------*

					case "MetricAltitudes":
						if (!fCountOnly)
							XMLDocument.Import(XMLNode, out m_fMetricAltitudes);
						break;
					case "MetricPressures":
						if (!fCountOnly)
							XMLDocument.Import(XMLNode, out m_fMetricPressures);
						break;
					case "MetricTemperatures":
						if (!fCountOnly)
							XMLDocument.Import(XMLNode, out m_fMetricTemperatures);
						break;

					//----------------------------------------------------------------------------*
					// Decimals
					//----------------------------------------------------------------------------*

					case "BulletWeightDecimals":
						if (!fCountOnly)
							XMLDocument.Import(XMLNode, out m_nBulletWeightDecimals);
						break;
					case "CanWeightDecimals":
						if (!fCountOnly)
							XMLDocument.Import(XMLNode, out m_nCanWeightDecimals);
						break;
					case "DimensionDecimals":
						if (!fCountOnly)
							XMLDocument.Import(XMLNode, out m_nDimensionDecimals);
						break;
					case "FirearmDecimals":
						if (!fCountOnly)
							XMLDocument.Import(XMLNode, out m_nFirearmDecimals);
						break;
					case "GroupDecimals":
						if (!fCountOnly)
							XMLDocument.Import(XMLNode, out m_nGroupDecimals);
						break;
					case "PowderWeightDecimals":
						if (!fCountOnly)
							XMLDocument.Import(XMLNode, out m_nPowderWeightDecimals);
						break;
					case "ShotWeightDecimals":
						if (!fCountOnly)
							XMLDocument.Import(XMLNode, out m_nShotWeightDecimals);
						break;

					//----------------------------------------------------------------------------*
					// Window sizes and locations
					//----------------------------------------------------------------------------*

					case "Maximized":
						if (!fCountOnly)
							XMLDocument.Import(XMLNode, out m_fMaximized);
						break;
					case "MainFormLocation":
						if (!fCountOnly)
							XMLDocument.Import(XMLNode, out m_MainFormLocation);
						break;
					case "MainFormSize":
						if (!fCountOnly)
							XMLDocument.Import(XMLNode, out m_MainFormSize);
						break;
					case "LastMainTabSelected":
						if (!fCountOnly)
							XMLDocument.Import(XMLNode, out m_strLastMainTabSelected);
						break;

					//----------------------------------------------------------------------------*
					// Ammo Tab Settings
					//----------------------------------------------------------------------------*

					case "AmmoPrintAll":
						if (!fCountOnly)
							XMLDocument.Import(XMLNode, out m_fAmmoPrintAll);
						break;
					case "AmmoPrintChecked":
						if (!fCountOnly)
							XMLDocument.Import(XMLNode, out m_fAmmoPrintChecked);
						break;
					case "AmmoPrintNonZero":
						if (!fCountOnly)
							XMLDocument.Import(XMLNode, out m_fAmmoNonZeroFilter);
						break;
					case "AmmoMinStockFilter":
						if (!fCountOnly)
							XMLDocument.Import(XMLNode, out m_fAmmoMinStockFilter);
						break;
					case "AmmoFactoryFilter":
						if (!fCountOnly)
							XMLDocument.Import(XMLNode, out m_fAmmoFactoryFilter);
						break;
					case "AmmoFactoryReloadFilter":
						if (!fCountOnly)
							XMLDocument.Import(XMLNode, out m_fAmmoFactoryReloadFilter);
						break;
					case "AmmoMyReloadFilter":
						if (!fCountOnly)
							XMLDocument.Import(XMLNode, out m_fAmmoFactoryReloadFilter);
						break;
					case "AmmoSortColumn":
						if (!fCountOnly)
							XMLDocument.Import(XMLNode, out m_nAmmoSortColumn);
						break;
					case "AmmoSortOrder":
						if (!fCountOnly)
							XMLDocument.Import(XMLNode, out m_AmmoSortOrder);
						break;

					//----------------------------------------------------------------------------*
					// Backup Settings
					//----------------------------------------------------------------------------*

					case "BackupOK":
						if (!fCountOnly)
							XMLDocument.Import(XMLNode, out m_fBackupOK);
						break;
					case "AutoBackup":
						if (!fCountOnly)
							XMLDocument.Import(XMLNode, out m_fAutoBackup);
						break;
					case "BackupFolder":
						if (!fCountOnly)
							XMLDocument.Import(XMLNode, out m_strBackupFolder);
						break;
					case "AutoSaveTime":
						if (!fCountOnly)
							XMLDocument.Import(XMLNode, out m_nAutoSaveTime);
						break;
					case "BackupKeepDays":
						if (!fCountOnly)
							XMLDocument.Import(XMLNode, out m_nBackupKeepDays);
						break;

					//----------------------------------------------------------------------------*
					// Ballistics Tab Settings
					//----------------------------------------------------------------------------*

					case "ShowApexMarker":
						if (!fCountOnly)
							XMLDocument.Import(XMLNode, out m_fShowApexMarker);
						break;
					case "ShowDropChartRangeMarkers":
						if (!fCountOnly)
							XMLDocument.Import(XMLNode, out m_fShowDropChartRangeMarkers);
						break;
					case "ShowGroundStrikeMarkers":
						if (!fCountOnly)
							XMLDocument.Import(XMLNode, out m_fShowGroundStrikeMarkers);
						break;
					case "ShowTransonicMarkers":
						if (!fCountOnly)
							XMLDocument.Import(XMLNode, out m_fShowTransonicMarkers);
						break;
					case "ShowWindDriftRangeMarkers":
						if (!fCountOnly)
							XMLDocument.Import(XMLNode, out m_fShowWindDriftRangeMarkers);
						break;
					case "BallisticsUseSF":
						if (!fCountOnly)
							XMLDocument.Import(XMLNode, out m_fBallisticsUseSF);
						break;

					//----------------------------------------------------------------------------*
					// Batch Load List
					//----------------------------------------------------------------------------*

					case "BatchLoadSortColumn":
						if (!fCountOnly)
							XMLDocument.Import(XMLNode, out m_nBatchLoadSortColumn);
						break;
					case "BatchLoadSortOrder":
						if (!fCountOnly)
							XMLDocument.Import(XMLNode, out m_BatchLoadSortOrder);
						break;

					//----------------------------------------------------------------------------*
					// Batch Print Form Settings
					//----------------------------------------------------------------------------*

					case "BatchPrintPaper":
						if (!fCountOnly)
							XMLDocument.Import(XMLNode, out m_nBatchPrintPaper);
						break;
					case "BatchPrintStartLabel":
						if (!fCountOnly)
							XMLDocument.Import(XMLNode, out m_nBatchPrintStartLabel);
						break;

					//----------------------------------------------------------------------------*
					// Bullet Caliber List settings
					//----------------------------------------------------------------------------*

					case "BulletCaliberSortColumn":
						if (!fCountOnly)
							XMLDocument.Import(XMLNode, out m_nBulletCaliberSortColumn);
						break;
					case "BulletCaliberSortOrder":
						if (!fCountOnly)
							XMLDocument.Import(XMLNode, out m_BulletCaliberSortOrder);
						break;

					//----------------------------------------------------------------------------*
					// Bullet Supply List settings
					//----------------------------------------------------------------------------*

					case "BulletSortColumn":
						if (!fCountOnly)
							XMLDocument.Import(XMLNode, out m_nBulletSortColumn);
						break;
					case "BulletSortOrder":
						if (!fCountOnly)
							XMLDocument.Import(XMLNode, out m_BulletSortOrder);
						break;

					//----------------------------------------------------------------------------*
					// Caliber List Settings
					//----------------------------------------------------------------------------*

					case "CaliberSortColumn":
						if (!fCountOnly)
							XMLDocument.Import(XMLNode, out m_nCaliberSortColumn);
						break;
					case "CaliberSortOrder":
						if (!fCountOnly)
							XMLDocument.Import(XMLNode, out m_CaliberSortOrder);
						break;

					//----------------------------------------------------------------------------*
					// Case Supply List Settings
					//----------------------------------------------------------------------------*

					case "CaseSortColumn":
						if (!fCountOnly)
							XMLDocument.Import(XMLNode, out m_nCaseSortColumn);
						break;
					case "CaseSortOrder":
						if (!fCountOnly)
							XMLDocument.Import(XMLNode, out m_CaseSortOrder);
						break;

					//----------------------------------------------------------------------------*
					// Charge List Settings
					//----------------------------------------------------------------------------*

					case "ChargeSortColumn":
						if (!fCountOnly)
							XMLDocument.Import(XMLNode, out m_nChargeSortColumn);
						break;
					case "ChargeSortOrder":
						if (!fCountOnly)
							XMLDocument.Import(XMLNode, out m_ChargeSortOrder);
						break;

					//----------------------------------------------------------------------------*
					// Charge Test List Settings
					//----------------------------------------------------------------------------*

					case "ChargeTestSortColumn":
						if (!fCountOnly)
							XMLDocument.Import(XMLNode, out m_nChargeTestSortColumn);
						break;
					case "ChargeTestSortOrder":
						if (!fCountOnly)
							XMLDocument.Import(XMLNode, out m_ChargeTestSortOrder);
						break;

					//----------------------------------------------------------------------------*
					// Conversion Calculator
					//----------------------------------------------------------------------------*

					case "ConversionDecimals":
						if (!fCountOnly)
							XMLDocument.Import(XMLNode, out m_nConversionDecimals);
						break;

					//----------------------------------------------------------------------------*
					// Copy Charge Form Settings
					//----------------------------------------------------------------------------*

					case "CopyChargeSortColumn":
						if (!fCountOnly)
							XMLDocument.Import(XMLNode, out m_nCopyChargeSortColumn);
						break;
					case "CopyChargeSortOrder":
						if (!fCountOnly)
							XMLDocument.Import(XMLNode, out m_CopyChargeSortOrder);
						break;

					//----------------------------------------------------------------------------*
					// Data Entry settings
					//----------------------------------------------------------------------------*

					case "AutoCheck":
						if (!fCountOnly)
							XMLDocument.Import(XMLNode, out m_fAutoCheck);
						break;
					case "AutoCheckNonZero":
						if (!fCountOnly)
							XMLDocument.Import(XMLNode, out m_fAutoCheckNonZero);
						break;
					case "ToolTips":
						if (!fCountOnly)
							XMLDocument.Import(XMLNode, out m_fToolTips);
						break;
					case "ShowArchivedBatches":
						if (!fCountOnly)
							XMLDocument.Import(XMLNode, out m_fShowArchivedBatches);
						break;

					//----------------------------------------------------------------------------*
					// Evaluation List Settings
					//----------------------------------------------------------------------------*

					case "EvaluationSortColumn":
						if (!fCountOnly)
							XMLDocument.Import(XMLNode, out m_nEvaluationSortColumn);
						break;
					case "EvaluationSortOrder":
						if (!fCountOnly)
							XMLDocument.Import(XMLNode, out m_EvaluationSortOrder);
						break;

					//----------------------------------------------------------------------------*
					// Firearm Tab Settings
					//----------------------------------------------------------------------------*

					case "FirearmAccessoryBipodFilter":
						if (!fCountOnly)
							XMLDocument.Import(XMLNode, out m_fFirearmAccessoryBipodFilter);
						break;
					case "FirearmAccessoryFurnitureFilter":
						if (!fCountOnly)
							XMLDocument.Import(XMLNode, out m_fFirearmAccessoryFurnitureFilter);
						break;
					case "FirearmAccessoryLaserFilter":
						if (!fCountOnly)
							XMLDocument.Import(XMLNode, out m_fFirearmAccessoryLaserFilter);
						break;
					case "FirearmAccessoryLightFilter":
						if (!fCountOnly)
							XMLDocument.Import(XMLNode, out m_fFirearmAccessoryLightFilter);
						break;
					case "FirearmAccessoryMagnifierFilter":
						if (!fCountOnly)
							XMLDocument.Import(XMLNode, out m_fFirearmAccessoryMagnifierFilter);
						break;
					case "FirearmAccessoryOtherFilter":
						if (!fCountOnly)
							XMLDocument.Import(XMLNode, out m_fFirearmAccessoryOtherFilter);
						break;
					case "FirearmAccessoryPartsFilter":
						if (!fCountOnly)
							XMLDocument.Import(XMLNode, out m_fFirearmAccessoryPartsFilter);
						break;
					case "FirearmAccessoryRedDotFilter":
						if (!fCountOnly)
							XMLDocument.Import(XMLNode, out m_fFirearmAccessoryRedDotFilter);
						break;
					case "FirearmAccessoryScopeFilter":
						if (!fCountOnly)
							XMLDocument.Import(XMLNode, out m_fFirearmAccessoryScopeFilter);
						break;
					case "FirearmAccessoryShowAll":
						if (!fCountOnly)
							XMLDocument.Import(XMLNode, out m_fFirearmAccessoryShowAll);
						break;
					case "FirearmAccessoryShowGroups":
						if (!fCountOnly)
							XMLDocument.Import(XMLNode, out m_fFirearmAccessoryShowGroups);
						break;
					case "FirearmAccessoryTriggerFilter":
						if (!fCountOnly)
							XMLDocument.Import(XMLNode, out m_fFirearmAccessoryTriggerFilter);
						break;

					//----------------------------------------------------------------------------*
					// Firearm Form Settings
					//----------------------------------------------------------------------------*

					case "FirearmBulletSortColumn":
						if (!fCountOnly)
							XMLDocument.Import(XMLNode, out m_nFirearmBulletSortColumn);
						break;
					case "FirearmBulletSortOrder":
						if (!fCountOnly)
							XMLDocument.Import(XMLNode, out m_FirearmBulletSortOrder);
						break;

					//----------------------------------------------------------------------------*
					// Firearm Image Settings
					//----------------------------------------------------------------------------*

					case "FirearmImagePath":
						if (!fCountOnly)
							XMLDocument.Import(XMLNode, out m_strFirearmImagePath);
						break;

					//----------------------------------------------------------------------------*
					// Firearm List Settings
					//----------------------------------------------------------------------------*

					case "FirearmPrintAll":
						if (!fCountOnly)
							XMLDocument.Import(XMLNode, out m_fFirearmPrintAll);
						break;
					case "FirearmPrintDetail":
						if (!fCountOnly)
							XMLDocument.Import(XMLNode, out m_fFirearmPrintDetail);
						break;
					case "FirearmPrintSpecs":
						if (!fCountOnly)
							XMLDocument.Import(XMLNode, out m_fFirearmPrintSpecs);
						break;
					case "FirearmSortColumn":
						if (!fCountOnly)
							XMLDocument.Import(XMLNode, out m_nFirearmSortColumn);
						break;
					case "FirearmSortOrder":
						if (!fCountOnly)
							XMLDocument.Import(XMLNode, out m_FirearmSortOrder);
						break;

					//----------------------------------------------------------------------------*
					// Hide Unchecked Button States
					//----------------------------------------------------------------------------*

					case "HideUncheckedCalibers":
						if (!fCountOnly)
							XMLDocument.Import(XMLNode, out m_fHideUncheckedCalibers);
						break;
					case "HideUncheckedSupplies":
						if (!fCountOnly)
							XMLDocument.Import(XMLNode, out m_fHideUncheckedSupplies);
						break;

					//----------------------------------------------------------------------------*
					// Inventory Activity Settings
					//----------------------------------------------------------------------------*

					case "LastActivityType":
						if (!fCountOnly)
							XMLDocument.Import(XMLNode, out m_eLastActivityType);
						break;
					case "LastPurchaseSource":
						if (!fCountOnly)
							XMLDocument.Import(XMLNode, out m_strLastPurchaseSource);
						break;
					case "LastAddStockReason":
						if (!fCountOnly)
							XMLDocument.Import(XMLNode, out m_strLastAddStockReason);
						break;
					case "LastReduceStockReason":
						if (!fCountOnly)
							XMLDocument.Import(XMLNode, out m_strLastReduceStockReason);
						break;
					case "LastFiredLocation":
						if (!fCountOnly)
							XMLDocument.Import(XMLNode, out m_strLastFiredLocation);
						break;
					case "ShowBatchTransactions":
						if (!fCountOnly)
							XMLDocument.Import(XMLNode, out m_fShowBatchTransactions);
						break;
					case "ShowArchivedTransactions":
						if (!fCountOnly)
							XMLDocument.Import(XMLNode, out m_fShowArchivedTransactions);
						break;

					//----------------------------------------------------------------------------*
					// Load Data List Settings
					//----------------------------------------------------------------------------*

					case "LoadDataSortColumn":
						if (!fCountOnly)
							XMLDocument.Import(XMLNode, out m_nLoadDataSortColumn);
						break;
					case "LoadDataSortOrder":
						if (!fCountOnly)
							XMLDocument.Import(XMLNode, out m_LoadDataSortOrder);
						break;

					//----------------------------------------------------------------------------*
					// Manufcturer List Settings
					//----------------------------------------------------------------------------*

					case "ManufacturerSortColumn":
						if (!fCountOnly)
							XMLDocument.Import(XMLNode, out m_nManufacturerSortColumn);
						break;
					case "ManufacturerSortOrder":
						if (!fCountOnly)
							XMLDocument.Import(XMLNode, out m_ManufacturerSortOrder);
						break;

					//----------------------------------------------------------------------------*
					// Powder Supply List Settings
					//----------------------------------------------------------------------------*

					case "PowderSortColumn":
						if (!fCountOnly)
							XMLDocument.Import(XMLNode, out m_nPowderSortColumn);
						break;
					case "PowderSortOrder":
						if (!fCountOnly)
							XMLDocument.Import(XMLNode, out m_PowderSortOrder);
						break;

					//----------------------------------------------------------------------------*
					// Primer Supply List Settings
					//----------------------------------------------------------------------------*

					case "PrimerSortColumn":
						if (!fCountOnly)
							XMLDocument.Import(XMLNode, out m_nPrimerSortColumn);
						break;
					case "PrimerSortOrder":
						if (!fCountOnly)
							XMLDocument.Import(XMLNode, out m_PrimerSortOrder);
						break;

					//----------------------------------------------------------------------------*
					// Supply Tab Settings
					//----------------------------------------------------------------------------*

					case "LastSupplyTypeSelected":
						if (!fCountOnly)
							XMLDocument.Import(XMLNode, out m_eLastSupplyTypeSelected);
						break;
					case "SupplyPrintAll":
						if (!fCountOnly)
							XMLDocument.Import(XMLNode, out m_fSupplyPrintAll);
						break;
					case "SupplyPrintChecked":
						if (!fCountOnly)
							XMLDocument.Import(XMLNode, out m_fSupplyPrintChecked);
						break;
					case "SupplyPrintNonZero":
						if (!fCountOnly)
							XMLDocument.Import(XMLNode, out m_fSupplyPrintNonZero);
						break;
					case "SupplyPrintBelowStock":
						if (!fCountOnly)
							XMLDocument.Import(XMLNode, out m_fSupplyPrintBelowStock);
						break;

					//----------------------------------------------------------------------------*
					// Target Calculator Colors
					//----------------------------------------------------------------------------*

					case "TargetAimPointColor":
						if (!fCountOnly)
							XMLDocument.Import(XMLNode, out m_TargetAimPointColor);
						break;
					case "TargetExtremesColor":
						if (!fCountOnly)
							XMLDocument.Import(XMLNode, out m_TargetExtremesColor);
						break;
					case "TargetGroupBoxColor":
						if (!fCountOnly)
							XMLDocument.Import(XMLNode, out m_TargetGroupBoxColor);
						break;
					case "TargetOffsetColor":
						if (!fCountOnly)
							XMLDocument.Import(XMLNode, out m_TargetOffsetColor);
						break;
					case "TargetReticleColor":
						if (!fCountOnly)
							XMLDocument.Import(XMLNode, out m_TargetReticleColor);
						break;
					case "TargetScaleBackcolor":
						if (!fCountOnly)
							XMLDocument.Import(XMLNode, out m_TargetScaleBackcolor);
						break;
					case "TargetScaleForecolor":
						if (!fCountOnly)
							XMLDocument.Import(XMLNode, out m_TargetScaleForecolor);
						break;
					case "TargetShotColor":
						if (!fCountOnly)
							XMLDocument.Import(XMLNode, out m_TargetShotColor);
						break;
					case "TargetShotForecolor":
						if (!fCountOnly)
							XMLDocument.Import(XMLNode, out m_TargetShotForecolor);
						break;

					//----------------------------------------------------------------------------*
					// Target Calculator Settings
					//----------------------------------------------------------------------------*

					case "TargetShowBoxesSet":
						if (!fCountOnly)
							XMLDocument.Import(XMLNode, out m_fTargetShowBoxesSet);
						break;
					case "TargetShowAimPoint":
						if (!fCountOnly)
							XMLDocument.Import(XMLNode, out m_fTargetShowAimPoint);
						break;
					case "TargetShowExtremes":
						if (!fCountOnly)
							XMLDocument.Import(XMLNode, out m_fTargetShowExtremes);
						break;
					case "TargetShowGroupBox":
						if (!fCountOnly)
							XMLDocument.Import(XMLNode, out m_fTargetShowGroupBox);
						break;
					case "TargetShowOffset":
						if (!fCountOnly)
							XMLDocument.Import(XMLNode, out m_fTargetShowOffset);
						break;
					case "TargetShowScale":
						if (!fCountOnly)
							XMLDocument.Import(XMLNode, out m_fTargetShowScale);
						break;
					case "TargetShowShotNum":
						if (!fCountOnly)
							XMLDocument.Import(XMLNode, out m_fTargetShowShotNum);
						break;

					//----------------------------------------------------------------------------*
					// Transaction List Settings
					//----------------------------------------------------------------------------*

					case "TransactionSortColumn":
						if (!fCountOnly)
							XMLDocument.Import(XMLNode, out m_nTransactionSortColumn);
						break;
					case "TransactionSortOrder":
						if (!fCountOnly)
							XMLDocument.Import(XMLNode, out m_TransactionSortOrder);
						break;
					default:
						break;
					}

				XMLNode = XMLNode.NextSibling;
				}

			return (true);
			}
		}
	}
