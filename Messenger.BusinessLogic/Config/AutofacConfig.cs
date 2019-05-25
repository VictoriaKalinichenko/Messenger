using Autofac;
using Messenger.BusinessLogic.Interfaces;
using Messenger.BusinessLogic.Services;

namespace Messenger.BusinessLogic.Config
{
    public class AutofacConfig : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<UserService>().As<IUserService>();
            builder.RegisterType<MessageService>().As<IMessageService>();

            builder.RegisterModule(new DataAccess.Config.AutofacConfig());
            base.Load(builder);
        }
    }
}
