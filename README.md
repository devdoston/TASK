# TASK2

API Usage Examples:

  Create User:
  - HTTP Method: POST
  - URL: https://localhost:7046/api/Users
  - Request Body: {name}
  - Expected Response: 200 Success
  
  Update User:
  - HTTP Method: PUT
  - URL: https://localhost:7046/api/Users?id=
  - Request Body: {name,posts}
  - Expected Response: 200 Success

  Create Post:
  - HTTP Method: POST
  - URL: https://localhost:7046/api/Posts?userId=
  - Request Body: { userId, title, content}
  - Expected Response: 200 Success

  Update Post:
  - HTTP Method: PUT
  - URL: https://localhost:7046/api/Posts?id=
  - Request Body: { userId, title, content}
  - Expected Response: 200 Success

  Create Comment:
  - HTTP Method: POST
  - URL: https://localhost:7046/api/Comments?postId=
  - Request Body: { postId, text}
  - Expected Response: 200 Success

  Update User:
  - HTTP Method: PUT
  - URL: https://localhost:7046/api/Comments?postId= &id=
  - Request Body: {postId, commentId, text}
  - Expected Response: 200 Success
