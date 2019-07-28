using Medulla.Engine.BattleProcessing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Medulla.Engine.Tests.BattleProcessing
{
    public class ActionProcessorTests
    {
        private BattleActionProcessor classUnderTest;

        [SetUp]
        public void SetUp()
        {
            classUnderTest = new BattleActionProcessor();
        }
        
    }
}
