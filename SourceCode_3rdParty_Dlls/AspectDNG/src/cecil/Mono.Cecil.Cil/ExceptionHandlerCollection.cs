//
// ExceptionHandlerCollection.cs
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

namespace Mono.Cecil.Cil {

	using System;
	using System.Collections;

	using Mono.Cecil.Cil;

	public sealed class ExceptionHandlerCollection : IExceptionHandlerCollection {

		IList m_items;
		MethodBody m_container;

		public event ExceptionHandlerEventHandler OnExceptionHandlerAdded;
		public event ExceptionHandlerEventHandler OnExceptionHandlerRemoved;

		public ExceptionHandler this [int index] {
			get { return m_items [index] as ExceptionHandler; }
			set { m_items [index] = value; }
		}

		object IIndexedCollection.this [int index] {
			get { return m_items [index]; }
		}

		public MethodBody Container {
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

		public ExceptionHandlerCollection (MethodBody container)
		{
			m_container = container;
			m_items = new ArrayList ();
		}

		public void Add (ExceptionHandler value)
		{
			if (OnExceptionHandlerAdded != null && !this.Contains (value))
				OnExceptionHandlerAdded (this, new ExceptionHandlerEventArgs (value));
			m_items.Add (value);
		}

		public void Clear ()
		{
			if (OnExceptionHandlerRemoved != null)
				foreach (ExceptionHandler item in this)
					OnExceptionHandlerRemoved (this, new ExceptionHandlerEventArgs (item));
			m_items.Clear ();
		}

		public bool Contains (ExceptionHandler value)
		{
			return m_items.Contains (value);
		}

		public int IndexOf (ExceptionHandler value)
		{
			return m_items.IndexOf (value);
		}

		public void Insert (int index, ExceptionHandler value)
		{
			if (OnExceptionHandlerAdded != null && !this.Contains (value))
				OnExceptionHandlerAdded (this, new ExceptionHandlerEventArgs (value));
			m_items.Insert (index, value);
		}

		public void Remove (ExceptionHandler value)
		{
			if (OnExceptionHandlerRemoved != null && this.Contains (value))
				OnExceptionHandlerRemoved (this, new ExceptionHandlerEventArgs (value));
			m_items.Remove (value);
		}

		public void RemoveAt (int index)
		{
			if (OnExceptionHandlerRemoved != null)
				OnExceptionHandlerRemoved (this, new ExceptionHandlerEventArgs (this [index]));
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

		public void Accept (ICodeVisitor visitor)
		{
			visitor.VisitExceptionHandlerCollection (this);
		}
	}
}
