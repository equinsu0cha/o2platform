//
// ConstructorCollection.cs
//
// Author:
//   Jb Evain (jbevain@gmail.com)
//
// Generated by /CodeGen/cecil-gen.rb do not edit
// Fri Apr 21 16:46:45 CEST 2006
//
// (C) 2005 Jb Evain
//
// Permission is hereby granted, free of charge, to any person obtaining
// a copy of this software and associated documentation files (the
// "Software"), to deal in the Software without restriction, including
// without limitation the rights to use, copy, modify, merge, publish,
// distribute, sublicense, and/or sell copies of the Software, and to
// permit persons to whom the Software is furnished to do so, subject to
// the following conditions:
//
// The above copyright notice and this permission notice shall be
// included in all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
// MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE
// LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION
// OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION
// WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
//

namespace Mono.Cecil {

	using System;
	using System.Collections;

	using Mono.Cecil.Cil;

	public sealed class ConstructorCollection : IConstructorCollection {

		IList m_items;
		TypeDefinition m_container;

		public event ConstructorEventHandler OnConstructorAdded;
		public event ConstructorEventHandler OnConstructorRemoved;

		public MethodDefinition this [int index] {
			get { return m_items [index] as MethodDefinition; }
			set { m_items [index] = value; }
		}

		object IIndexedCollection.this [int index] {
			get { return m_items [index]; }
		}

		public TypeDefinition Container {
			get { return m_container; }
		}

		public int Count {
			get { return m_items.Count; }
		}

		public bool IsSynchronized {
			get { return false; }
		}

		public object SyncRoot {
			get { return this; }
		}

		public ConstructorCollection (TypeDefinition container)
		{
			m_container = container;
			m_items = new ArrayList ();
		}

		public void Add (MethodDefinition value)
		{
			if (OnConstructorAdded != null && !this.Contains (value))
				OnConstructorAdded (this, new ConstructorEventArgs (value));
			m_items.Add (value);
		}

		public void Clear ()
		{
			if (OnConstructorRemoved != null)
				foreach (MethodDefinition item in this)
					OnConstructorRemoved (this, new ConstructorEventArgs (item));
			m_items.Clear ();
		}

		public bool Contains (MethodDefinition value)
		{
			return m_items.Contains (value);
		}

		public int IndexOf (MethodDefinition value)
		{
			return m_items.IndexOf (value);
		}

		public void Insert (int index, MethodDefinition value)
		{
			if (OnConstructorAdded != null && !this.Contains (value))
				OnConstructorAdded (this, new ConstructorEventArgs (value));
			m_items.Insert (index, value);
		}

		public void Remove (MethodDefinition value)
		{
			if (OnConstructorRemoved != null && this.Contains (value))
				OnConstructorRemoved (this, new ConstructorEventArgs (value));
			m_items.Remove (value);
		}

		public void RemoveAt (int index)
		{
			if (OnConstructorRemoved != null)
				OnConstructorRemoved (this, new ConstructorEventArgs (this [index]));
			m_items.RemoveAt (index);
		}

		public void CopyTo (Array ary, int index)
		{
			m_items.CopyTo (ary, index);
		}

		public IEnumerator GetEnumerator ()
		{
			return m_items.GetEnumerator ();
		}

		public MethodDefinition GetConstructor (bool isStatic, Type [] parameters)
		{
			foreach (MethodDefinition ctor in this) {
				if (ctor.IsStatic == isStatic && ctor.Parameters.Count == parameters.Length) {
					if (parameters.Length == 0)
						return ctor;
					for (int i = 0; i < parameters.Length; i++)
						if (ctor.Parameters [i].ParameterType.FullName ==  ReflectionHelper.GetTypeSignature (parameters [i]))
							return ctor;
				}
			}

			return null;
		}

		public MethodDefinition GetConstructor (bool isStatic, ITypeReference [] parameters)
		{
			foreach (MethodDefinition ctor in this)
				if (ctor.IsStatic == isStatic && ctor.Parameters.Count == parameters.Length)
					for (int i = 0; i < parameters.Length; i++)
						if (ctor.Parameters [i].ParameterType.FullName == parameters [i].FullName)
							return ctor;

			return null;
		}

		public void Accept (IReflectionVisitor visitor)
		{
			visitor.VisitConstructorCollection (this);
		}
	}
}
