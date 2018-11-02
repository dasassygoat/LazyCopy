# LazyCopy

This is a very rough almost protype version of the app. There are lots of extra comments, and in other places probably missing comments.

Need to do a lot of refactoring, like I said its almost a protype so lots of code cleanup needed.

Functionaility Missing:
* read and store paths somewhere else
* no checking to make sure that all source and destination paths are created
* not compareing zip file hashes to see if there are differences between the temp file (new file) and the destination file (previously saved)
* no file management of deleting or moving temporary files, or moving the previously saved zip to the correct place
* encrypt files
* restore functionality -- critical once encryption is used
