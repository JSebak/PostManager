

export class Post {
    id: string;
    authorId: string;
    title: string;
    content: string;
    status: string | null;
    creationDate: string;
    approvalDate: string|null;


    constructor() {
        this.id = "";
        this.authorId = "";
        this.title = "";
        this.content = "";
        this.status = "false";
        this.creationDate = "";
        this.approvalDate = null
    }
}