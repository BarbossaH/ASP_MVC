using System;
namespace CMVC.Services
{
	public class ScopedGuidService:IScopedGuidServices
	{
		private readonly Guid Id;
		public ScopedGuidService()
		{
			Id = Guid.NewGuid();
		}
		public string GetGuid()
		{
			return Id.ToString();
		}
	}
}

