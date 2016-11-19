﻿//============================================================================*
// cChargeList.cs
//
// Copyright © 2013-2014, Kevin S. Beebe
// All Rights Reserved
//============================================================================*

//============================================================================*
// .Net Using Statements
//============================================================================*

using System;
using System.Collections.Generic;
using System.Xml;

//============================================================================*
// Namespace
//============================================================================*

namespace ReloadersWorkShop
	{
	//============================================================================*
	// cChargeList Class
	//============================================================================*

	[Serializable]
	public class cChargeList : List<cCharge>
		{
		//============================================================================*
		// cChargeList() - Constructor
		//============================================================================*

		public cChargeList()
			{
			}

		//============================================================================*
		// cChargeList() - Copy Constructor
		//============================================================================*

		public cChargeList(cChargeList ChargeList)
			{
			foreach (cCharge Charge in ChargeList)
				{
				cCharge NewCharge = new cCharge(Charge);

				Add(NewCharge);
				}

			Sort(new cChargeComparer());
			}

		//============================================================================*
		// Add()
		//============================================================================*

		new public void Add(cCharge Charge)
			{
			base.Add(Charge);

			Sort(new cChargeComparer());
			}

		//============================================================================*
		// Export()
		//============================================================================*

		public void Export(XmlDocument XMLDocument, XmlElement XMLParentElement)
			{
			XmlElement XMLElement = XMLDocument.CreateElement("Charges");
			XMLParentElement.AppendChild(XMLElement);

			foreach (cCharge Charge in this)
				{
				Charge.Export(XMLDocument, XMLElement);
				}
			}
		}
	}
