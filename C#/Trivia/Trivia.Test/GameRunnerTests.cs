using System;
using System.IO;
using NUnit.Framework;
using UglyTrivia;

namespace Trivia.Test
{
   public class GameRunnerTests
    {

        //[Test]
        //public void GenerateMaster()
        //{
        //    TextWriter oldConsole = Console.Out;

        //    using (   var fs = new FileStream( "gameResult.txt", FileMode.Create )  )
        //    {
        //        using ( var sw = new StreamWriter( fs )  )
        //        {
        //            Console.SetOut( sw );

        //            // begin capture  output
        //            for ( int i = 0; i < 1000; i++ )
        //            {
        //                Random r = new Random( i );
        //                GameRunner.RunGame( r );
        //            }
        //            // save output

        //            sw.Flush();
        //            fs.Flush();
        //        }
        //    }

        //    Console.SetOut( oldConsole );
        //}

        [Test]
        public void CompareMaster()
        {
            TextWriter oldConsole = Console.Out;

            using ( var fs = new FileStream( "testRun.txt", FileMode.Create ) )
            {
                using ( var sw = new StreamWriter( fs ) )
                {
                    Console.SetOut( sw );

                    // begin capture  output
                    for ( int i = 0; i < 1000; i++ )
                    {
                        Random r = new Random( i );
                        GameRunner.RunGame( r );
                    }
                    // save output

                    sw.Flush();
                    fs.Flush();
                }
            }
            Console.SetOut( oldConsole );

            var master = File.ReadAllText( "gameResult.txt" );
            var testRun = File.ReadAllText( "testRun.txt" );

            Assert.AreEqual( master, testRun );
        }

    }
}
