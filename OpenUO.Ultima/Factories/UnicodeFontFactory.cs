﻿#region License Header
// /***************************************************************************
//  *   Copyright (c) 2011 OpenUO Software Team.
//  *   All Right Reserved.
//  *
//  *   UnicodeFontFactory.cs
//  *
//  *   This program is free software; you can redistribute it and/or modify
//  *   it under the terms of the GNU General Public License as published by
//  *   the Free Software Foundation; either version 3 of the License, or
//  *   (at your option) any later version.
//  ***************************************************************************/
#endregion

#region References
using OpenUO.Core.Patterns;
using OpenUO.Ultima.Adapters;
#endregion

namespace OpenUO.Ultima
{
	public class UnicodeFontFactory : AdapterFactoryBase
	{
		public UnicodeFontFactory(InstallLocation install, IContainer container)
			: base(install, container)
		{ }

		public T GetText<T>(int fontId, string text, short hueId)
		{
			return GetAdapter<IUnicodeFontStorageAdapter<T>>().GetText(fontId, text, hueId);
		}

		public int GetFontHeight<T>(int fontId)
		{
			return GetAdapter<IUnicodeFontStorageAdapter<T>>().GetFontHeight(fontId);
		}
	}
}