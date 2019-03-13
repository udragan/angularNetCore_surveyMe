import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { OAuthService, JwksValidationHandler } from 'angular-oauth2-oidc';

import { authConfig } from 'src/assets/configuration/auth-config';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html'
})
export class NavComponent {

    public isLoggedIn: boolean;

    constructor(private http: HttpClient,
                private oauthService: OAuthService) {
        this.configureWithNewConfigApi();
    }

    public login() {
        this.oauthService.initImplicitFlow();
    }

    public logout() {
        this.oauthService.logOut();
        this.isLoggedIn = false;
    }

    public register() {
        const url = 'http://localhost:2884/Identity/Account/Register';
        this.http.get(url)
            .subscribe(
                () => { console.log('111'); },
                (err) => { console.log(err); }
            );
    }

    public get name() {
        const claims = this.oauthService.getIdentityClaims();

        if (!claims) {
            return null;
        }

        return claims.given_name;
    }

    private configureWithNewConfigApi() {
        this.oauthService.configure(authConfig);
        this.oauthService.tokenValidationHandler = new JwksValidationHandler();
        this.oauthService.loadDiscoveryDocumentAndTryLogin()
            .then(
                (data: boolean) => {
                    console.log(data); this.isLoggedIn = data;
                },
                (reason: any) => {
                    console.log(`Reason: ${reason}`);
                });
    }

}
