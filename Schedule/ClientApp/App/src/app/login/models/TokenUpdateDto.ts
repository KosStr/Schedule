export class TokenUpdateDto {
  accessToken: string;

  constructor(token: Partial<TokenUpdateDto>) {
    this.accessToken = token.accessToken;
  }
}
