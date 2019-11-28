export interface UserRequest {
  UserName: string;
  Password: string;
}

export interface UserRequestRegistration extends UserRequest {
  ConfirmPassword: string;
  CountryName: string;
}

export interface UserResponseDTO {
  token: string;
}
