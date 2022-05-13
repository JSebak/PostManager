import { Component, EventEmitter, Input, OnInit, Output } from "@angular/core";
import { Post } from "../Models/post.model";

@Component({
    selector: 'dashboard-component',
    templateUrl: './dashboard.component.html',
    //   styleUrls: ['./post.component.css']
})
export class DashboardComponent implements OnInit {
    posts: any;
    selectedPost!: Post;
    reviewedPost!: Post;
    @Input() user: any;
    count: number = 0;
    @Output() logoutUser = new EventEmitter<boolean>();

    constructor() {
    }
    ngOnInit() {
    }

    redirect() {
        this.user.role == "Writer" ? this.count = 1 : this.count = 2;
    }

    home() {
        this.count = 0;
    }
    myPosts() {
        this.count = 5
    }

    logout() {
        sessionStorage.removeItem("user");
        this.logoutUser.emit(true);
    }
    edit(value: boolean) {
        this.count = 3
    }

    selected(post: Post) {
        this.selectedPost = post;
        this.count = 4
    }

}