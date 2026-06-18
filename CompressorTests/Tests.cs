using Compressor;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using NUnit.Framework.Constraints;

namespace CompressorTests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Compress_aaabbcccdde()
        {
            Assert.That(CompressorDecompressor.Compress("aaabbcccdde"), Is.EqualTo("a3b2c3d2e"));
        }
        [Test]
        public void Compress_empty()
        {
            Assert.That(CompressorDecompressor.Compress(""), Is.EqualTo(""));
        }
        [Test]
        public void Compress_non_character()
        {
            Assert.Throws<InvalidDataException>(() => CompressorDecompressor.Compress("qwer%"));
        }
        [Test]
        public void Compress_one_character()
        {
            Assert.That(CompressorDecompressor.Compress("q"), Is.EqualTo("q"));
        }
        [Test]
        public void Compress_single_character()
        {
            Assert.That(CompressorDecompressor.Compress("rrrrrrrrr"), Is.EqualTo("r9"));
        }
    }
}