using System;
using System.Collections.Generic;
using System.Text;

namespace GAP.Medical.Appointment.Domain.ValueObjects
{
    public class DocumentId : IEquatable<DocumentId>
    {
        private string _text;

        private DocumentId() { }

        public DocumentId(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                throw new DocumentIdShouldNotBeEmptyException("The 'Name' field is required");

            _text = text;
        }

        public override string ToString()
        {
            return _text;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (obj is string)
            {
                return obj.ToString() == _text;
            }

            return ((DocumentId)obj)._text == _text;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17;
                hash = hash * 23 + _text.GetHashCode();
                return hash;
            }
        }

        public bool Equals(DocumentId other)
        {
            return this._text == other._text;
        }

    }
}
