# BlazorWebApp_Auth
- Blazor Web App에서 Cookie를 사용하여 인증 처리하였음, (The Blazor Web app authenticated using cookies)

* 웹소켓을 사용하기 때문에 http 응답 처리가 어려움

* 별도의 자바 스크립트를 이용하여 쿠키 값을 브라우저에 저장




### 📂 프로젝트 구조 설명

- **Components**  
  - Razor 코드로 구성된 웹 클라이언트 부분
  
- **Controller**  
  - 인증을 위한 API Controller
  
- **Model**  
  - 웹 클라이언트와 API Controller 간의 통신에 사용하는 데이터 전송용 모델
  
- **Utilities**  
  - 쿠키 저장을 위한 클래스
  
- **wwwroot/js**  
  - 쿠키 저장을 위한 JavaScript 파일
