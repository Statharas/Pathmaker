
scp -r 'C:\Users\Stath\source\repos\Pathmaker\Pathmaker\bin\Release\net6.0\browser-wasm\publish\*' 'stathisthemagic@efpapadopoulos.com:~/public_html'
echo "Copied"
ssh 'stathisthemagic@efpapadopoulos.com' 'rm -R "~/public_html/pathmaker"'
echo "Removed pathmaker"
ssh 'stathisthemagic@efpapadopoulos.com' 'mv "~/public_html/wwwroot" "~/public_html/pathmaker"'
echo "Moved new files in pathmaker"