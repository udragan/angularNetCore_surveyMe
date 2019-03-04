
import { Component } from '@angular/core';
import { OAuthService, JwksValidationHandler } from 'angular-oauth2-oidc';

import { authConfig } from '../assets/configuration/auth-config';

@Component({
    selector: 'app-root',
    templateUrl: './app.component.html'
})
export class AppComponent {
    title = 'Client';
    public isLoggedIn: boolean;

    constructor(private oauthService: OAuthService) {
        this.configureWithNewConfigApi();
    }

    public login() {
        this.oauthService.initImplicitFlow();
    }

    public logout() {
        this.oauthService.logOut();
        this.isLoggedIn = false;
    }

    private configureWithNewConfigApi() {
        this.oauthService.configure(authConfig);
        this.oauthService.tokenValidationHandler = new JwksValidationHandler();
        this.oauthService.loadDiscoveryDocumentAndTryLogin()
            .then(
                (value: boolean) => {
                    console.log(value); this.isLoggedIn = value;
                },
                (reason: any) => {
                    console.log(`Reason: ${reason}`);
                });
    }
}
