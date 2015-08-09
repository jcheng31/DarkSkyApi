namespace ForecastPCL.Test
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using ForecastIOPortable;

    using NUnit.Framework;


    [TestFixture]
    public class LanguageTests
    {
        [Test]
        public void AllLanguagesHaveValues()
        {
            foreach (Language language in Enum.GetValues(typeof(Language)))
            {
                Assert.That(() => language.ToValue(), Throws.Nothing);
            }
        }
    }
}
