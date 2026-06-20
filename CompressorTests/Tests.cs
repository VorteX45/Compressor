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



        [Test]
        public void Decompress_a3b2c3d2e()
        {
            Assert.That(CompressorDecompressor.Decompress("a3b2c3d2e"), Is.EqualTo("aaabbcccdde"));
        }


        [Test]
        public void Decompress_one_character()
        {
            Assert.That(CompressorDecompressor.Decompress("a"), Is.EqualTo("a"));
        }


        [Test]
        public void Decompress_empty()
        {
            Assert.That(CompressorDecompressor.Decompress(""), Is.EqualTo(""));
        }


        [Test]
        public void Decompress_non_character()
        {
            Assert.Throws<InvalidDataException>(() => CompressorDecompressor.Decompress("qwer%"));
        }


        [Test]
        public void Decompress_many_characters()
        {
            Assert.That(CompressorDecompressor.Decompress("a10b"), Is.EqualTo("aaaaaaaaaab"));
        }


        [Test]
        public void Decompress_starts_with_number()
        {
            Assert.Throws<InvalidDataException>(() => CompressorDecompressor.Decompress("9q"));
        }
    }
}