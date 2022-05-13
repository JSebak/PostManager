import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { CommentModel } from "src/app/Models/comment.model";
import { Post } from "src/app/Models/post.model";
import { DateService } from "../Shared/date.service";

@Injectable({ providedIn: 'root', })
export class CommentService {
    private _url = "https://localhost:7286/api/";
    private _endpoint = "comment";

    constructor(private http: HttpClient, private dateService: DateService) {
    }

    add(comment: CommentModel): Observable<any> {
        comment.creationDate = this.dateService.generateDate();
        return this.http.post<any>(`${this._url}${this._endpoint}/Create`,comment);
    }
    getbypost(postId: string){
        return this.http.get<any>(`${this._url}${this._endpoint}/Get/${postId}`)
    }
    delete(commentId: string){
        return this.http.delete<any>(`${this._url}${this._endpoint}/Delete?comment=${commentId}`)
    }
    update(post: Post){
        return this.http.put<any>(`${this._url}${this._endpoint}/Update`,{
            id: post.id,
            title: post.title,
            content: post.content
        })
    }

}