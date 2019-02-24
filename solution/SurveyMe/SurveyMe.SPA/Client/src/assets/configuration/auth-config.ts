import { AuthConfig } from 'angular-oauth2-oidc';

export const authConfig: AuthConfig = {

    // Url of the Identity Provider
    issuer: 'http://localhost:2884',

    // URL of the SPA to redirect the user to after login
    // redirectUri: window.location.origin + '/index.html',
    redirectUri: 'http://localhost:4200/home',

    // The SPA's id. The SPA is registerd with this id at the auth-server
    clientId: 'SPA',

    // set the scope for the permissions the client should request
    // The first three are defined by OIDC. The 4th is a usecase-specific one
    scope: 'openid profile ', // email
};
