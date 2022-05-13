
export class CommentModel {
    id: string;
    authorId: string | null;
    postId: string;
    content: string;
    creationDate: string;


    constructor() {
        this.id = "";
        this.authorId = "";
        this.postId = "";
        this.content = "";
        this.creationDate = "";
    }
}