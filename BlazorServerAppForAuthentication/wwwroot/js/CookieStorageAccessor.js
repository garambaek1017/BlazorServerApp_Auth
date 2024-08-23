// 쿠키 정보 조회 
export function get()
{
    return document.cookie;
}

// 쿠키 정보 저장 
export function set(key, value)
{
    document.cookie = `${key}=${value}`;
}

// 쿠키 제거, 만료일을 현재시간 이전으로 설정 
export function remove(key) {
    document.cookie = key + "=; Max-Age=0; path=/";
}