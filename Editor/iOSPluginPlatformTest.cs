using NUnit.Framework;
using System.Linq;
using System.Text;
using UnityEditor;

namespace Kogane.Internal
{
	internal sealed class iOSPluginPlatformTest
	{
		[Category( nameof( Kogane ) )]
		[Test]
		public void iOS_プラグインのプラットフォームが適切か()
		{
			var list = AssetDatabase
					.GetAllAssetPaths()
					.Where( c => c.Contains( "/Plugins/" ) )
					.Where( c => c.Contains( "/iOS/" ) )
					.Select( c => AssetImporter.GetAtPath( c ) )
					.OfType<PluginImporter>()
					.Where( c => c != null )
					.Where( c => c.GetCompatibleWithPlatform( BuildTarget.Android ) )
					.Select( c => AssetDatabase.GetAssetPath( c ) )
				;

			if ( !list.Any() ) return;

			var sb = new StringBuilder();

			foreach ( var n in list )
			{
				sb.AppendLine( n );
			}

			Assert.Fail( sb.ToString() );
		}
	}
}