type EnvVariables = {
    BACKEND_HOST: string;
    JWT_SECRET: string;
}

export function getEnv(): EnvVariables {
     return {
        BACKEND_HOST: process.env.BACKEND_HOST || '',
        JWT_SECRET: process.env.JWT_SECRET || ''
    }
}