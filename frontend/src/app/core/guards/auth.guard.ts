import { Injectable } from "@angular/core";
import { CanActivate, Router, UrlTree } from "@angular/router";
import { LocalDbService } from "../services/local-db.service";

@Injectable()
export class AuthGuard implements CanActivate {
  constructor(private router: Router, private localDbService: LocalDbService) {}

  canActivate(): boolean | UrlTree {
    const token = this.localDbService.getAccessToken();
    return token === null ? this.router.parseUrl("/auth/login") : true;
  }
}
