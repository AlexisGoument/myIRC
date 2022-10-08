module Base64

let decode str =
    System.Convert.FromBase64String str
    |> System.Text.Encoding.ASCII.GetString