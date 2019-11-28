import { Injectable } from "@angular/core";

@Injectable({
  providedIn: "root"
})
export class LocalDbService {
  private readonly ACCESS_TOKEN = "AccessToken";

  constructor() {}

  storeToken(accessToken: string): void {
    localStorage.setItem(this.ACCESS_TOKEN, accessToken);
  }

  getAccessToken(): string {
    return localStorage.getItem(this.ACCESS_TOKEN);
  }
}
