using System;
namespace CMVC.Services
{
	public class TransientGuidService:ITransientGuidService
	{
		public TransientGuidService()
		{
            Id = Guid.NewGuid();

        }
       
        private readonly Guid Id;

        public string GetGuid()
        {
            return Id.ToString();
        }
    }
}

