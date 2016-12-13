﻿//============================================================================*
// cManufacturer.cs
//
// Copyright © 2013-2014, Kevin S. Beebe
// All Rights Reserved
//============================================================================*

//============================================================================*
// .Net Using Statements
//============================================================================*

using System;
using System.Xml;

//============================================================================*
// NameSpace
//============================================================================*

namespace ReloadersWorkShop
	{
	//============================================================================*
	// cManufacturer class
	//============================================================================*

	[Serializable]
	public partial class cManufacturer : IComparable
		{
		//----------------------------------------------------------------------------*
		// Private Data Members
		//----------------------------------------------------------------------------*

		// Company Info

		private string m_strName = "";
		private string m_strWebsite = "";
		private bool m_fWebsiteVisited = false;

		// Supplies

		private bool m_fBullets = false;
		private bool m_fPrimers = false;
		private bool m_fCases = false;
		private bool m_fPowder = false;
		private bool m_fAmmo = false;
		private bool m_fBulletMolds = false;

		private string m_strHeadStamp = "";

		// Firearms

		private bool m_fHandguns = false;
		private bool m_fRifles = false;
		private bool m_fShotguns = false;

		// Firearm Accessories

		private bool m_fScopes = false;
		private bool m_fLasers = false;
		private bool m_fRedDots = false;
		private bool m_fMagnifiers = false;
		private bool m_fLights = false;
		private bool m_fTriggers = false;
		private bool m_fFurniture = false;
		private bool m_fBipods = false;
		private bool m_fParts = false;
		private bool m_fMisc = false;

		//============================================================================*
		// cManufacturer() - Constructor
		//============================================================================*

		public cManufacturer()
			{
			}

		//============================================================================*
		// cManufacturer() - Copy Constructor
		//============================================================================*

		public cManufacturer(cManufacturer Manufacturer)
			{
			Copy(Manufacturer);
			}

		//============================================================================*
		// Ammo Property
		//============================================================================*

		public bool Ammo
			{
			get
				{
				return (m_fAmmo);
				}
			set
				{
				m_fAmmo = value;
				}
			}

		//============================================================================*
		// Parts Property
		//============================================================================*

		public bool Parts
			{
			get
				{
				return (m_fParts);
				}
			set
				{
				m_fParts = value;
				}
			}

		//============================================================================*
		// Bipods Property
		//============================================================================*

		public bool Bipods
			{
			get
				{
				return (m_fBipods);
				}
			set
				{
				m_fBipods = value;
				}
			}

		//============================================================================*
		// Bullets Property
		//============================================================================*

		public bool Bullets
			{
			get
				{
				return (m_fBullets);
				}
			set
				{
				m_fBullets = value;
				}
			}

		//============================================================================*
		// BulletMolds Property
		//============================================================================*

		public bool BulletMolds
			{
			get
				{
				return (m_fBulletMolds);
				}
			set
				{
				m_fBulletMolds = value;
				}
			}

		//============================================================================*
		// Cases Property
		//============================================================================*

		public bool Cases
			{
			get
				{
				return (m_fCases);
				}
			set
				{
				m_fCases = value;
				}
			}

		//============================================================================*
		// Comparer()
		//============================================================================*

		public static int Comparer(cManufacturer Manufacturer1, cManufacturer Manufacturer2)
			{
			if (Manufacturer1 == null)
				{
				if (Manufacturer2 != null)
					return (-1);
				else
					return (0);
				}

			return (Manufacturer1.CompareTo(Manufacturer2));
			}

		//============================================================================*
		// CompareTo()
		//============================================================================*

		public int CompareTo(Object obj)
			{
			if (obj == null)
				return (1);

			cManufacturer Manufacturer = (cManufacturer) obj;

			//----------------------------------------------------------------------------*
			// Name
			//----------------------------------------------------------------------------*

			return (Name.ToUpper().CompareTo(Manufacturer.Name.ToUpper()));
			}

		//============================================================================*
		// Copy()
		//============================================================================*

		public void Copy(cManufacturer Manufacturer)
			{
			m_strName = Manufacturer.m_strName;
			m_strWebsite = Manufacturer.m_strWebsite;
			m_fWebsiteVisited = Manufacturer.m_fWebsiteVisited;

			m_fAmmo = Manufacturer.m_fAmmo;
			m_fBullets = Manufacturer.m_fBullets;
			m_fCases = Manufacturer.m_fCases;
			m_fPowder = Manufacturer.m_fPowder;
			m_fPrimers = Manufacturer.m_fPrimers;
			m_fBulletMolds = Manufacturer.m_fBulletMolds;

			m_strHeadStamp = Manufacturer.m_strHeadStamp;

			m_fHandguns = Manufacturer.m_fHandguns;
			m_fRifles = Manufacturer.m_fRifles;
			m_fShotguns = Manufacturer.m_fShotguns;

			m_fScopes = Manufacturer.m_fScopes;
			m_fLasers = Manufacturer.m_fLasers;
			m_fRedDots = Manufacturer.m_fRedDots;
			m_fMagnifiers = Manufacturer.m_fMagnifiers;
			m_fLights = Manufacturer.m_fLights;
			m_fTriggers = Manufacturer.m_fTriggers;
			m_fFurniture = Manufacturer.m_fFurniture;
			m_fBipods = Manufacturer.m_fBipods;
			m_fParts = Manufacturer.m_fParts;
			m_fMisc = Manufacturer.m_fMisc;
			}

		//============================================================================*
		// Handguns Property
		//============================================================================*

		public bool Handguns
			{
			get
				{
				return (m_fHandguns);
				}
			set
				{
				m_fHandguns = value;
				}
			}

		//============================================================================*
		// HasGear()
		//============================================================================*

		public bool HasGear(cGear.eGearTypes eType)
			{
			switch (eType)
				{
				case cGear.eGearTypes.Scope:
					return (m_fScopes);
				case cGear.eGearTypes.Laser:
					return (m_fLasers);
				case cGear.eGearTypes.RedDot:
					return (m_fRedDots);
				case cGear.eGearTypes.Magnifier:
					return (m_fMagnifiers);
				case cGear.eGearTypes.Light:
					return (m_fLights);
				case cGear.eGearTypes.Trigger:
					return (m_fTriggers);
				case cGear.eGearTypes.Furniture:
					return (m_fFurniture);
				case cGear.eGearTypes.Bipod:
					return (m_fBipods);
				case cGear.eGearTypes.Parts:
					return (m_fParts);
				}

			return (m_fMisc);
			}


		//============================================================================*
		// HeadStamp Property
		//============================================================================*

		public string HeadStamp
			{
			get
				{
				return (m_strHeadStamp);
				}
			set
				{
				m_strHeadStamp = value;
				}
			}

		//============================================================================*
		// Import()
		//============================================================================*

		public bool Import(XmlDocument XMLDocument, XmlNode XMLThisNode)
			{
			XmlNode XMLNode = XMLThisNode.FirstChild;

			while (XMLNode != null)
				{
				switch (XMLNode.Name)
					{
					case "Name":
						m_strName = XMLNode.FirstChild.Value;
						break;
					case "Website":
						m_strWebsite = XMLNode.FirstChild.Value;
						break;
					case "Bullets":
						m_fBullets = XMLNode.FirstChild.Value == "Yes";
						break;
					case "Powders":
						m_fPowder = XMLNode.FirstChild.Value == "Yes";
						break;
					case "Primers":
						m_fPrimers = XMLNode.FirstChild.Value == "Yes";
						break;
					case "Cases":
						m_fCases = XMLNode.FirstChild.Value == "Yes";
						break;
					case "BulletMolds":
						m_fBulletMolds = XMLNode.FirstChild.Value == "Yes";
						break;
					case "HeadStamp":
						m_strHeadStamp = XMLNode.FirstChild.Value;
						break;
					case "Ammo":
						m_fAmmo = XMLNode.FirstChild.Value == "Yes";
						break;
					case "Handguns":
						m_fHandguns = XMLNode.FirstChild.Value == "Yes";
						break;
					case "Rifles":
						m_fRifles = XMLNode.FirstChild.Value == "Yes";
						break;
					case "Shotguns":
						m_fShotguns = XMLNode.FirstChild.Value == "Yes";
						break;
					case "Scopes":
						m_fScopes = XMLNode.FirstChild.Value == "Yes";
						break;
					case "Lasers":
						m_fLasers = XMLNode.FirstChild.Value == "Yes";
						break;
					case "RedDots":
						m_fRedDots = XMLNode.FirstChild.Value == "Yes";
						break;
					case "Magnifiers":
						m_fMagnifiers = XMLNode.FirstChild.Value == "Yes";
						break;
					case "Lights":
						m_fLights = XMLNode.FirstChild.Value == "Yes";
						break;
					case "Triggers":
						m_fTriggers = XMLNode.FirstChild.Value == "Yes";
						break;
					case "Furniture":
					case "Stocks":
						m_fFurniture = XMLNode.FirstChild.Value == "Yes";
						break;
					case "Bipods":
						m_fBipods = XMLNode.FirstChild.Value == "Yes";
						break;
					case "FirearmParts":
						m_fParts = XMLNode.FirstChild.Value == "Yes";
						break;
					case "Other":
						 m_fMisc = XMLNode.FirstChild.Value == "Yes";
						break;
					}

				XMLNode = XMLNode.NextSibling;
				}

			return (Validate());
			}

		//============================================================================*
		// Lasers Property
		//============================================================================*

		public bool Lasers
			{
			get
				{
				return (m_fLasers);
				}
			set
				{
				m_fLasers = value;
				}
			}

		//============================================================================*
		// Lights Property
		//============================================================================*

		public bool Lights
			{
			get
				{
				return (m_fLights);
				}
			set
				{
				m_fLights = value;
				}
			}

		//============================================================================*
		// Magnifiers Property
		//============================================================================*

		public bool Magnifiers
			{
			get
				{
				return (m_fMagnifiers);
				}
			set
				{
				m_fMagnifiers = value;
				}
			}

		//============================================================================*
		// Misc Property
		//============================================================================*

		public bool Misc
			{
			get
				{
				return (m_fMisc);
				}
			set
				{
				m_fMisc = value;
				}
			}

		//============================================================================*
		// Name Property
		//============================================================================*

		public string Name
			{
			get
				{
				return (m_strName);
				}
			set
				{
				m_strName = value;
				}
			}

		//============================================================================*
		// Powder Property
		//============================================================================*

		public bool Powder
			{
			get
				{
				return (m_fPowder);
				}
			set
				{
				m_fPowder = value;
				}
			}

		//============================================================================*
		// Primer Property
		//============================================================================*

		public bool Primers
			{
			get
				{
				return (m_fPrimers);
				}
			set
				{
				m_fPrimers = value;
				}
			}

		//============================================================================*
		// RedDots Property
		//============================================================================*

		public bool RedDots
			{
			get
				{
				return (m_fRedDots);
				}
			set
				{
				m_fRedDots = value;
				}
			}

		//============================================================================*
		// Rifles Property
		//============================================================================*

		public bool Rifles
			{
			get
				{
				return (m_fRifles);
				}
			set
				{
				m_fRifles = value;
				}
			}

		//============================================================================*
		// Scopes Property
		//============================================================================*

		public bool Scopes
			{
			get
				{
				return (m_fScopes);
				}
			set
				{
				m_fScopes = value;
				}
			}

		//============================================================================*
		// Shotguns Property
		//============================================================================*

		public bool Shotguns
			{
			get
				{
				return (m_fShotguns);
				}
			set
				{
				m_fShotguns = value;
				}
			}

		//============================================================================*
		// Furniture Property
		//============================================================================*

		public bool Furniture
			{
			get
				{
				return (m_fFurniture);
				}
			set
				{
				m_fFurniture = value;
				}
			}

		//============================================================================*
		// ToString Property
		//============================================================================*

		public override string ToString()
			{
			string strString = m_strName;

			return (strString);
			}

		//============================================================================*
		// Triggers Property
		//============================================================================*

		public bool Triggers
			{
			get
				{
				return (m_fTriggers);
				}
			set
				{
				m_fTriggers = value;
				}
			}

		//============================================================================*
		// Validate()
		//============================================================================*

		public bool Validate()
			{
			if (String.IsNullOrEmpty(m_strName))
				return (false);

			if (m_fCases && String.IsNullOrEmpty(m_strHeadStamp))
				return (false);

			if (!m_fAmmo && !m_fBipods && !m_fBulletMolds && !m_fBullets && !m_fCases &&
				!m_fFurniture && !m_fHandguns && !m_fLasers && !m_fLights && !m_fMagnifiers &&
				!m_fMisc && !m_fParts && !m_fPowder && !m_fPrimers && !m_fRedDots &&
				!m_fRifles && !m_fScopes && !m_fShotguns && !m_fTriggers)
				return (false);

			return (true);
			}

		//============================================================================*
		// Website Property
		//============================================================================*

		public string Website
			{
			get
				{
				return (m_strWebsite);
				}
			set
				{
				m_strWebsite = value;
				}
			}

		//============================================================================*
		// WebSitevisited Property
		//============================================================================*

		public bool WebSiteVisited
			{
			get
				{
				return (m_fWebsiteVisited);
				}
			set
				{
				m_fWebsiteVisited = value;
				}
			}
		}
	}
