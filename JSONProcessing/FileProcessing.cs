namespace JSONProcessing
{

    /// <summary>
    /// A class for working with Files.
    /// </summary>
    public static class FileProcessing
    {

        /// <summary>
        /// A method for checking absolute path for writting.
        /// </summary>
        /// <param name="Path">Absolute path of the file.</param>
        /// <returns>Boolean value depence on correctness of the path.</returns>
        public static bool FileIsAvailibleToCreate(string Path)
        {
            try
            {
                using (File.Create(Path)) { }
                if (File.Exists(Path))
                {
                    Thread.Sleep(5000);
                    File.Delete(Path);
                    return true;
                }
                else { return false; }
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}