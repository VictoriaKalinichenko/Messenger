using Messenger.DataAccess.Interfaces;
using Microsoft.AspNetCore.SignalR;
using System;

namespace Messenger.BusinessLogic.Providers
{
  public class CustomUserIdProvider : IUserIdProvider
  {
    private readonly IUserRepository _userRepository;

    public CustomUserIdProvider(IUserRepository userRepository)
    {
      _userRepository = userRepository;
    }

    public string GetUserId(HubConnectionContext context)
    {
      string userId = _userRepository.GetIdByName(context.User.Identity.Name).GetAwaiter().GetResult();
      return userId;
    }
  }
}
