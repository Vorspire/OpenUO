﻿#region License Header
// /***************************************************************************
//  *   Copyright (c) 2011 OpenUO Software Team.
//  *   All Right Reserved.
//  *
//  *   ExecutionChainStepBase.cs
//  *
//  *   This program is free software; you can redistribute it and/or modify
//  *   it under the terms of the GNU General Public License as published by
//  *   the Free Software Foundation; either version 3 of the License, or
//  *   (at your option) any later version.
//  ***************************************************************************/
#endregion

#region References
using System.Collections.Generic;
#endregion

namespace OpenUO.Core.Patterns
{
	public abstract class ExecutionChainStepBase<T> : IChainStep<T>
		where T : class
	{
		private readonly List<ChainDependency> _dependencies;
		private IChainStep<T> _successor;

		public ExecutionChainStepBase()
		{
			_dependencies = new List<ChainDependency>();
		}

		public virtual string Name { get { return GetType().Name; } }

		public IChain<T> Chain { get; set; }

		public bool CancelExecution { get; set; }

		public IChainStep<T> Successor
		{
			get { return _successor; }
			set
			{
				Guard.AssertIsNotNull(value, "value");

				if (_successor == null)
				{
					_successor = value;
				}
				else
				{
					var successor = _successor;
					_successor = value;
					value.Successor = successor;
				}
			}
		}

		public ChainDependency[] Dependencies { get { return _dependencies.ToArray(); } }

		public void Execute(T state)
		{
			ExecuteOverride(state);

			if (!CancelExecution && _successor != null)
			{
				_successor.Execute(state);
			}
		}

		public void AddDepenency(string name, bool mustExist)
		{
			_dependencies.Add(new ChainDependency(name, mustExist));
		}

		protected abstract void ExecuteOverride(T state);
	}
}