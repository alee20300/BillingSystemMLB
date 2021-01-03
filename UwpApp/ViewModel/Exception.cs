using System;

namespace UwpApp.ViewModel
{
    public class MemoSavingException : Exception

    {

        public MemoSavingException() : base("Error Saving a Memo.")
        {

        }

        public MemoSavingException(string messege) : base(messege)
        {

        }

        public MemoSavingException(string messege, Exception innerException) : base(messege, innerException)
        {

        }
    }
}
