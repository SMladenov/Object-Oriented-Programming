
using Dealership.Models.Contracts;
using System.Collections.Generic;

namespace Dealership.Models
{
    public class Comment : IComment
    {
        public const int CommentMinLength = 3;
        public const int CommentMaxLength = 200;
        public const string InvalidCommentError = "Content must be between 3 and 200 characters long!";

        private string content;
        private string author;

        public Comment(string content, string author)
        {
            Validator.ValidateIntRange(content.Length, CommentMinLength, CommentMaxLength, InvalidCommentError);
            Content = content;
            Author = author;
        }

        public string Content
        {
            get { return content; }
            set { this.content = value; }
        }

        public string Author
        {
            get { return author; }
            set { this.author = value; }
        }

        //ToDo
    }
}
