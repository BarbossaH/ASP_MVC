using System;
namespace CMVC.Services
{
	public class SingletionGuidService:ISingletionGuidService
	{
		public SingletionGuidService()
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

