﻿using Autofac;
using Messenger.DataAccess.Interfaces;
using Messenger.DataAccess.Repositories;

namespace Messenger.DataAccess.Config
{
    public class AutofacConfig : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<UserRepository>()
                .As<IUserRepository>();

            base.Load(builder);
        }
    }
}
