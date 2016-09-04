    public class utilities
    {
        public static bool IsValidImage(string filename)
        {
            try
            {
                WebRequest Request1 = WebRequest.Create(filename);

                WebResponse Responce1 = Request1.GetResponse();
                
                Image img1 = Image.FromStream(Responce1.GetResponseStream());



            }
            catch
            {
                // Image.FromFile will throw this if file is invalid.
                // Don't ask me why.
                return false;
            }
            return true;
        }
