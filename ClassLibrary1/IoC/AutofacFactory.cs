using Autofac;
using Project.Business.Abstract;
using Project.Business.Logger;
using Project.Business.Logger.LoggerTransaction;
using Project.Business.Operation;
using Project.DataAccess.Abstract;
using Project.DataAccess.DbAccess.DataLayer;

namespace Project.Business.IoC {
    public class AutofacFactory : Module {
        protected override void Load(ContainerBuilder builder) {
            //base.Load(builder);
            builder.RegisterType<CategoryOperations>().As<ICategoryOperations>().SingleInstance();
            builder.RegisterType<ProductOperations>().As<IProductOperations>().SingleInstance();

            builder.RegisterType<CategoryDL>().As<ICategoryDL>().SingleInstance();
            builder.RegisterType<ProductDL>().As<IProductDL>().SingleInstance();

            builder.RegisterType<FileLogOperation>().As<ILogger>().SingleInstance();


        }
    }
}
