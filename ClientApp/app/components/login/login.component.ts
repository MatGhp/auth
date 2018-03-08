import { Component, Inject } from '@angular/core';
import { Http } from '@angular/http';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
    selector: 'fetchdata',
    templateUrl: './login.component.html'
})

export class LoginComponent {
    model: any = {};
    loading = false;
   // returnUrl: string;
 
    constructor(
        private http: Http,
        private route: ActivatedRoute,
        private router: Router) { }

    public login() {
        this.http.post('http://localhost:5000/api/account/login', { username: this.model.username, password: this.model.password }).subscribe(result => {
            console.log('login', result);
        }, error => console.error(error));
    }
}
