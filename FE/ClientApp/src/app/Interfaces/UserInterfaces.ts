export interface User {
    id?: number
    userTypeId?: number
    UserTitleId?: number
    name?: string
    surname?: string
    emailAddress?: string
    birthDate?: Date
    titleDescription?: string
    typeDescription?: string
    typeCode?: string
    isActive?: boolean
}

export interface UserCreateEdit {
    id?: number
    userTypeId?: number
    userTitleId?: number
    name?: string
    surname?: string
    emailAddress?: string
    birthDate?: Date
    isActive?: boolean
}

export interface UserTitle {
    id?: number
    description?: string
}

export interface UserType {
    id?: number
    description?: string
    code?: string
}