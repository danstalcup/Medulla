using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Autofac;
using Medulla.Engine;
using Medulla.Engine.BattleProcessing;
using Medulla.Engine.Rendering;

namespace Medulla
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var builder = new ContainerBuilder();

            Register(builder);

            var container = builder.Build();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            using (var scope = container.BeginLifetimeScope())
            {
                Application.Run(new Form1(scope.Resolve<GameEngine>()));
            }
        }

        private static void Register(ContainerBuilder builder)
        {
            builder.RegisterType<GameEngine>();
            builder.RegisterType<BattleRender>().As<IBattleRender>();
            builder.RegisterType<BattleTeamRender>().As<IBattleTeamRender>();
            builder.RegisterType<BattleUnitRender>().As<IBattleUnitRender>();
            builder.RegisterType<ActionFinder>().As<IActionFinder>();
            builder.RegisterType<NextUnitFinder>().As<INextUnitFinder>();
            builder.RegisterType<TeamFinder>().As<ITeamFinder>();
            builder.RegisterType<TargetUnitsFinder>().As<ITargetUnitsFinder>();
            builder.RegisterType<CooldownUpdater>().As<ICooldownUpdater>();
            builder.RegisterType<BattleActionProcessor>().As<IBattleActionProcessor>();
        }
    }
}
